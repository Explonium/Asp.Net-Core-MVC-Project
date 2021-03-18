using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Mvc_Project_Client.Models;
using Mvc_Project_Client.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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
                var result = await _requestService.SendRequestAsync(HttpMethod.Get, "api/account/getMyInformation");
                var user = await _requestService.DeserializeAsync<User>(result);

                ViewData["User"] = user;
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
                var result = await _requestService.SendRequestAsync(HttpMethod.Post, "api/account/signin", credentials);
                await UpdateUserInfoAsync();

                return RedirectToAction("Index", "Home");
            }
            catch (ApiException e)
            {
                try
                {
                    foreach (var error in e.ErrorsInfo.Errors)
                        foreach (var errorMessage in error.Value)
                            ModelState.AddModelError(error.Key, errorMessage);
                }
                catch
                {
                    ModelState.AddModelError("", e.Message);
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
                await _requestService.SendRequestAsync(HttpMethod.Post, "api/account/register", userDetails);
                return RedirectToAction("Index", "Home");
            }
            catch(ApiException e)
            {
                foreach (var error in e.ErrorsInfo.Errors)
                    foreach (var errorMessage in error.Value)
                        ModelState.AddModelError(error.Key, errorMessage);

                return View();
            }
        }

        public async Task<IActionResult> SignOut()
        {
            try
            {
                await _requestService.SendRequestAsync(HttpMethod.Post, "api/account/signout");
                return RedirectToAction("Index", "Home");
            }
            catch (ApiException e)
            {
                foreach (var error in e.ErrorsInfo.Errors)
                    foreach (var errorMessage in error.Value)
                        ModelState.AddModelError(error.Key, errorMessage);
                
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
                //JsonPatchDocument<User> userPatch = new JsonPatchDocument<User>();
                
                //userPatch.Replace(m => m.FirstName, user.FirstName);
                //userPatch.Replace(m => m.LastName, user.LastName);

                var result = await _requestService.SendRequestAsync(HttpMethod.Put, "api/account/updatePersonalInformation", user);
                return RedirectToAction("Profile");
            }
            catch (ApiException e)
            {
                return RedirectToAction("Profile");
            }
        }
    }
}