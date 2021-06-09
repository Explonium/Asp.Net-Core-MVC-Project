using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Mvc_Project_Client.Models;
using Mvc_Project_Client.Services;
using Mvc_Project_Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mvc_Project_Client.Controllers
{
    [Authorize(Roles = "owner")]
    public class DatabaseController : Controller
    {
        private readonly IRequestService _requestService;

        public DatabaseController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Categories()
        {
            var result = await _requestService.SendRequestAsync(HttpMethod.Get, "api/categories");
            var categories = await _requestService.DeserializeAsync<List<Category>>(result);

            return View(new CategoriesDatabaseViewModel { Categories = categories });
        }

        public async Task<IActionResult> SubCategories()
        {
            var result = await _requestService.SendRequestAsync(HttpMethod.Get, "api/categories");
            var categories = await _requestService.DeserializeAsync<List<Category>>(result);

            result = await _requestService.SendRequestAsync(HttpMethod.Get, "api/subcategories/");
            var subCategories = await _requestService.DeserializeAsync<List<SubCategory>>(result);

            return View(new SubCategoriesDatabaseViewModel { Categories = categories, SubCategories = subCategories });
        }

        public async Task<IActionResult> Currencies()
        {
            var currencies = await _requestService.GetList<Currency>("Currencies");

            return View(new CurrenciesDatabaseViewModel { Currencies = currencies });
        }

        public async Task<IActionResult> Countries()
        {
            var currencies = (await _requestService.GetList<Currency>("Currencies"))
                .ToDictionary(x => x.Id.ToString(), x => x.Name);
            var countries = await _requestService.GetList<Country>("Countries");

            return View(new CountriesDatabaseViewModel { Currencies = currencies, Countries = countries });
        }

        public async Task<IActionResult> Cities()
        {
            var countries = (await _requestService.GetList<Country>("Countries"))
                .ToDictionary(x => x.Id.ToString(), x => x.Name);
            var cities = await _requestService.GetList<City>("Cities");

            return View(new CitiesDatabaseViewModel { Cities = cities, Countries = countries });
        }
        public async Task<IActionResult> Manufacturers()
        {
            var manufacturers = await _requestService.GetList<Manufacturer>("Manufacturers");

            return View(new ManufacturersDatabaseViewModel { Manufacturers = manufacturers });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] Category category)
        {
            await _requestService.SendRequestAsync(HttpMethod.Post, "api/categories/", category);

            return RedirectToAction("Categories");
        }

        [HttpPost]
        public async Task<JsonResult> UpdateCategory(Category category)
        {
            await _requestService.SendRequestAsync(HttpMethod.Put, "api/categories/" + category.Id.ToString(), category);

            return Json(new { Status = "Success" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory([FromForm] Category category)
        {
            await _requestService.SendRequestAsync(HttpMethod.Delete, "api/categories/" + category.Id.ToString());

            return RedirectToAction("Categories");
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory([FromForm] SubCategory subCategory)
        {
            await _requestService.SendRequestAsync(HttpMethod.Post, "api/subcategories/", subCategory);

            return RedirectToAction("SubCategories");
        }

        [HttpPost]
        public async Task<JsonResult> UpdateSubCategory([FromForm] SubCategory subCategory)
        {
            await _requestService.SendRequestAsync(HttpMethod.Put, "api/subcategories/" + subCategory.Id.ToString(), subCategory);

            return Json(new { Status = "Success" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSubCategory([FromForm] SubCategory subCategory)
        {
            await _requestService.Delete("Subcategories", subCategory.Id.ToString());

            return RedirectToAction("SubCategories");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCurrency([FromForm] Currency currency)
        {
            await _requestService.Post("Currencies", currency);

            return RedirectToAction("Currencies");
        }

        [HttpPost]
        public async Task<JsonResult> UpdateCurrency([FromForm] Currency currency)
        {
            await _requestService.Put("Currencies", currency, currency.Id.ToString());

            return Json(new { Status = "Success" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCurrency([FromForm] Currency currency)
        {
            await _requestService.Delete("Currencies", currency.Id.ToString());

            return RedirectToAction("Currencies");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromForm] Country country)
        {
            await _requestService.Post("Countries", country);

            return RedirectToAction("Countries");
        }

        [HttpPost]
        public async Task<JsonResult> UpdateCountry([FromForm] Country country)
        {
            await _requestService.Put("Countries", country, country.Id.ToString());

            return Json(new { Status = "Success" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCountry([FromForm] Country country)
        {
            await _requestService.Delete("Countries", country.Id.ToString());

            return RedirectToAction("Countries");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity([FromForm] City city)
        {
            await _requestService.Post("Cities", city);

            return RedirectToAction("Cities");
        }

        [HttpPost]
        public async Task<JsonResult> UpdateCity([FromForm] City city)
        {
            await _requestService.Put("Cities", city, city.Id.ToString());

            return Json(new { Status = "Success" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCity([FromForm] City city)
        {
            await _requestService.Delete("Cities", city.Id.ToString());

            return RedirectToAction("Cities");
        }

        [HttpPost]
        public async Task<IActionResult> CreateManufacturer([FromForm] Manufacturer manufacturer)
        {
            await _requestService.Post("Manufacturers", manufacturer);

            return RedirectToAction("Manufacturer");
        }

        [HttpPost]
        public async Task<JsonResult> UpdateManufacturer([FromForm] Manufacturer manufacturer)
        {
            await _requestService.Put("Manufacturers", manufacturer, manufacturer.Id.ToString());

            return Json(new { Status = "Success" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteManufacturer([FromForm] Manufacturer manufacturer)
        {
            await _requestService.Delete("Manufacturers", manufacturer.Id.ToString());

            return RedirectToAction("Manufacturer");
        }
    }
}
