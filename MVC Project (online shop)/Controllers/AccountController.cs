using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Project__online_shop_.Entities;
using MVC_Project__online_shop_.Models;
using MVC_Project__online_shop_.Services;

namespace MVC_Project__online_shop_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> db;
        private readonly SignInManager<User> sim;
        private readonly IEmailService _emailService;

        public AccountController(UserManager<User> context, SignInManager<User> signInManager, IEmailService emailService)
        {
            db = context;
            sim = signInManager;
            _emailService = emailService;

            if (!db.Users.Any())
            {
                // Add admin user!
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<User>> GetCurrentUserData()
        {
            var user = await db.GetUserAsync(sim.Context.User);
            if (user == null)
                return NotFound("This user doesn't exist");

            return Ok(user);
        }

        [HttpGet]
        [Authorize]
        [Route("sendEmailConfirmationUrl")]
        public async Task<IActionResult> SendEmailConfirmationUrl()
        {
            var user = await db.GetUserAsync(sim.Context.User);
            if (user == null)
                return NotFound("This user doesn't exist");

            var code = await db.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = user.Id, code = code },
                protocol: HttpContext.Request.Scheme);

            await _emailService.SendEmailAsync(user.Email, "Confirm your email", "");

            return Ok();
        }

        [HttpGet]
        [Route("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("Code is not valid");
            }
            var user = await db.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var result = await db.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return Ok("An email has been confirmed");
            else
                return BadRequest("Code is not valid");
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] UserLoginModel credentials)
        {
            // Checking model errors
            if (!ModelState.IsValid || credentials == null)
                return new BadRequestObjectResult(new { Message = "Incorrect username or password" }); 

            // Finding user
            var identityUser = await db.FindByNameAsync(credentials.Username);
            if (identityUser == null)
            {
                identityUser = await db.FindByEmailAsync(credentials.Username);
                if (identityUser == null)
                    return new BadRequestObjectResult(new { Message = "Incorrect username or password" });
            }

            // Trying to sign in
            var signInResult = await sim.PasswordSignInAsync(identityUser, credentials.Password, true, false);

            if (signInResult.Succeeded)
                return Ok(new { Message = "You are logged in" });
            else
                return new BadRequestObjectResult(new { Message = "Incorrect username or password" });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel userDetails)
        {
            //if (!ModelState.IsValid || userDetails == null)
            //    return new BadRequestObjectResult(new { Message = "User Registration Failed" });

            var identityUser = new User() { UserName = userDetails.Username, Email = userDetails.Email };
            var result = await db.CreateAsync(identityUser, userDetails.Password);
            
            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors) 
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }
                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }
            return Ok(new { Message = "User Reigstration Successful" });
        }

        [HttpPost]
        [Route("signout")]
        public async Task<IActionResult> Logout() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { Message = "You are logged out" });
        }
    }
}
