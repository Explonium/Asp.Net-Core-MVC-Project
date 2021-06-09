using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Project_Client.Controllers
{
    public class VendorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyStorages()
        {
            return View();
        }

        public IActionResult MyStocks()
        {
            return View();
        }

        public IActionResult MyProducts()
        {
            return View();
        }
    }
}
