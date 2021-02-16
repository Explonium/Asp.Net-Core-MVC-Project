using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Client.Models;
using MVC_Project.Client.Services;

namespace MVC_Project.Client.Controllers
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.9.4.0 (NJsonSchema v10.3.1.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class AccountController : Controller
    {
        private IRequestService _requestService;

        public AccountController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginModel credentials)
        {
            if (credentials == null)
                throw new System.ArgumentNullException("credentials");

            var response_ = await _requestService.SendRequestAsync(HttpMethod.Post, "api/Account/signin", credentials);

            return RedirectToAction("Main", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel userDetails)
        {
            try{
                if (userDetails == null)
                    throw new System.ArgumentNullException("userDetails");

                var response = await _requestService.SendRequestAsync(HttpMethod.Post, "api/account/register", userDetails);
                return RedirectToAction("Main", "Home");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            return await Logout(System.Threading.CancellationToken.None);
        }

        public async System.Threading.Tasks.Task<IActionResult> Logout(System.Threading.CancellationToken cancellationToken)
        {
            var response = await _requestService.SendRequestAsync(HttpMethod.Post, "api/signout");
            return RedirectToAction("Main", "Home");
        }
    }
}
