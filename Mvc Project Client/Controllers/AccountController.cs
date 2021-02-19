using Microsoft.AspNetCore.Http;
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

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromForm] UserLoginModel credentials)
        {
            try
            {
                await _requestService.SendRequestAsync(HttpMethod.Post, "api/account/signin", credentials);
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


        public async Task<IActionResult> Profile()
        {
            try
            {
                var result = await _requestService.SendRequestAsync(HttpMethod.Get, "api/account");
                var user = await _requestService.DeserializeAsync<User>(result);

                return View(user);
            }
            catch (ApiException e)
            {
                //foreach (var error in e.ErrorsInfo.Errors)
                //    foreach (var errorMessage in error.Value)
                //        ModelState.AddModelError(error.Key, errorMessage);

                return View();
            }
        }
    }
}