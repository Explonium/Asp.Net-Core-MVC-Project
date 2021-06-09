using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Project_Client.Controllers
{
    public class StoragesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
