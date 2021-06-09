using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Mvc_Project_Client.Models;
using Mvc_Project_Client.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;
using System;

namespace Mvc_Project_Client.Controllers
{
    public partial class AccountController : Controller
    {
        public IRequestService _requestService;

        public AccountController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task UpdateUserInfoAsync()
        {
            try
            {
                ViewData["User"] = await _requestService.Get<User>("MyInformation");
            }
            catch
            {
                ViewData["User"] = null;
            }
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromForm] UserLoginModel credentials)
        {
            try
            {
                await _requestService.Post("SignIn", credentials);
                await Authenticate(credentials.Username);
                await UpdateUserInfoAsync();

                return RedirectToAction("Index", "Home");
            }
            catch (ApiException e)
            {
                try
                {
                    foreach (var errorInfo in e.ErrorsInfo.Errors)
                        foreach (var error in errorInfo.Value.Errors)
                            ModelState.AddModelError(errorInfo.Key, error.ErrorMessage);

                    ModelState.AddModelError("", e.ErrorsInfo.Message);
                }
                catch
                {
                    ModelState.AddModelError("", e.ErrorsInfo.Message);
                }

                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] UserRegisterModel userDetails)
        {
            try
            {
                await _requestService.Post("Register", userDetails);
                return RedirectToAction("Index", "Home");
            }
            catch (ApiException e)
            {
                foreach (var errorInfo in e.ErrorsInfo.Errors)
                    foreach (var error in errorInfo.Value.Errors)
                        ModelState.AddModelError(errorInfo.Key, error.ErrorMessage);

                ModelState.AddModelError("", e.ErrorsInfo.Message);

                return View();
            }
        }

        public async Task<IActionResult> SignOut()
        {
            try
            {
                await _requestService.SendRequestAsync(HttpMethod.Post, "api/account/signout");
                await HttpContext.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (ApiException e)
            {
                foreach (var errorInfo in e.ErrorsInfo.Errors)
                    foreach (var error in errorInfo.Value.Errors)
                        ModelState.AddModelError(errorInfo.Key, error.ErrorMessage);

                ModelState.AddModelError("", e.ErrorsInfo.Message);

                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            await UpdateUserInfoAsync();
            return View(ViewData["User"]);
        }

        [HttpPost]
        public async Task<IActionResult> Profile([FromForm] User user)
        {
            try
            {
                JsonPatchDocument<User> userPatch = new JsonPatchDocument<User>();
                //userPatch.Replace(m => m.LastName, user.LastName);

                var result = await _requestService.SendRequestAsync(HttpMethod.Put, "api/account/updatePersonalInformation", user);
                return RedirectToAction("Profile");
            }
            catch (ApiException)
            {
                return RedirectToAction("Profile");
            }
        }

        [HttpPost]
        public async Task<JsonResult> PutPersonalInformation(UserProfilePersonalInfo model)
        {
            await _requestService.Put("PutUserPPI", model);
            return Json(new { Status = "Success" });
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            var roles = await _requestService.GetList<string>("GetRoles");

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> BecomeVendor()
        {
            try
            {
                await _requestService.SendRequestAsync(HttpMethod.Post, "api/vendors/become");
            }
            catch (ApiException) { }
            return RedirectToAction("Profile");
        }
    }
}