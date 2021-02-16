using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Project__online_shop_.Entities;
using MVC_Project__online_shop_.Models;

namespace MVC_Project__online_shop_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> db;
        private readonly SignInManager<User> sim;

        public AccountController(UserManager<User> context, SignInManager<User> signInManager)
        {
            db = context;
            sim = signInManager;

            if (!db.Users.Any())
            {
                // Add admin user!
                
            }
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] UserLoginModel credentials)
        {
            // Checking model errors
            if (!ModelState.IsValid || credentials == null)
            {
                return new BadRequestObjectResult(new { Message = "Incorrect username or password" }); 
            }

            // Finding user
            var identityUser = await db.FindByNameAsync(credentials.Username);
            if (identityUser == null)
            {
                identityUser = await db.FindByEmailAsync(credentials.Username);
                if (identityUser == null)
                    return new BadRequestObjectResult(new { Message = "Incorrect username or password" });
            }

            // Comparing password
            var result = db.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, credentials.Password);
            if (result == PasswordVerificationResult.Failed) 
            { 
                return new BadRequestObjectResult(new { Message = "Incorrect username or password" }); 
            }

            // Generating claims and identity
            var claims = new List<Claim>
            { 
                new Claim(ClaimTypes.Email, identityUser.Email),
                new Claim(ClaimTypes.Name, identityUser.UserName)
            };
            
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return Ok(new { Message = "You are logged in" });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel userDetails)
        {
            if (!ModelState.IsValid || userDetails == null)
                return new BadRequestObjectResult(new { Message = "User Registration Failed" });

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
