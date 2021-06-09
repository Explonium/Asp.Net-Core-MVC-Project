using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class AccountController : ControllerBase
    {
        private readonly UserManager<User> db;
        private readonly SignInManager<User> sim;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> context, SignInManager<User> signInManager, IEmailService emailService, IMapper mapper)
        {
            db = context;
            sim = signInManager;
            _emailService = emailService;
            _mapper = mapper;

            if (!db.Users.Any())
            {
                var userDetails = new UserRegisterModel
                {
                    Username = "MvcProjectTeam-Owner",
                    Email = "aleksej.zubov.01@mail.ru",
                    Password = "DefaultPassword1",
                    ConfirmPassword = "DefaultPassword1"
                };

                var user = Register(userDetails);
                db.AddToRoleAsync(db.FindByNameAsync("MvcProjectTeam-Owner").Result, "owner");
            }
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
        public async Task<ActionResult<UserReturnModel>> Register([FromBody] UserRegisterModel userDetails)
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
            return Ok(_mapper.Map<UserReturnModel>(await db.FindByNameAsync(userDetails.Username)));
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
