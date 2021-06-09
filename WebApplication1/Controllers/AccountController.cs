using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
using MvcProjectApi.Entities;
using MvcProjectApi.Models;
using MvcProjectApi.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace MvcProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class AccountController : ControllerBase
    {
        private readonly UserManager<User> db;
        private readonly SignInManager<User> sim;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> context, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IEmailService emailService, IMapper mapper)
        {
            db = context;
            sim = signInManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _mapper = mapper;

            /*
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
            */
        }

        [HttpPost]
        [Route("signin")]
        public async Task<ActionResult<UserLoginModel>> SignIn([FromBody] UserLoginModel credentials)
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
            var signInResult = await sim.PasswordSignInAsync(identityUser, credentials.Password, true, true);

            if (signInResult.Succeeded)
                return Ok(new UserLoginModel { 
                    Username = credentials.Username,
                    Password = "hidden"});
            else if (signInResult.IsLockedOut)
                return new BadRequestObjectResult(new { Message = "This account has recieved temporary or permanent ban" });
            else
                return new BadRequestObjectResult(new { Message = "Incorrect username or password" });
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserRegisterModel>> Register([FromBody] UserRegisterModel userDetails)
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
            return Ok(new UserRegisterModel { 
                Username = userDetails.Username, 
                Email = userDetails.Email, 
                Password = "hidden",
                ConfirmPassword = "hidden" });
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
