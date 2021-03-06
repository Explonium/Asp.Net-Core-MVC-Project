﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc_Project_Client.Models;
using Mvc_Project_Client.Services;
using Mvc_Project_Client.ViewModels;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mvc_Project_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRequestService _requestService;

        public HomeController(IRequestService requestService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _requestService = requestService;
        }

        public async Task<IActionResult> Index()
        {
            IndexHomeModel model = new IndexHomeModel();

            try
            {
               // var result = await _requestService.SendRequestAsync(HttpMethod.Get, "api/account/getMyInformation");
                //var user = await _requestService.Get<User>("MyInformation");

                model.User = await _requestService.Get<User>("MyInformation");
                ViewData["User"] = model.User;
            }
            catch { }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
