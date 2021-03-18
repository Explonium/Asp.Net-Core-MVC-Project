using Microsoft.AspNetCore.Mvc;
using Mvc_Project_Client.Models;
using Mvc_Project_Client.Services;
using Mvc_Project_Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mvc_Project_Client.ViewComponents
{
    [ViewComponent(Name = "Categories")]
    public class CategoriesComponent : ViewComponent
    {
        private readonly IRequestService _requestService;

        public CategoriesComponent(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var catResponse = await _requestService.SendRequestAsync(HttpMethod.Get, "https://localhost:51044/api/categories");
            var catList = await _requestService.DeserializeAsync<List<CategoryReturnModel>>(catResponse);

            var subResponse = await _requestService.SendRequestAsync(HttpMethod.Get, "https://localhost:51044/api/categories/subcategories");
            var subList = await _requestService.DeserializeAsync<List<SubCategoryReturnModel>>(subResponse);

            var model = new CategoriesViewModel();

            foreach (var category in catList)
                model.Categories.Add(category, new List<SubCategoryReturnModel>());

            foreach (var subCategory in subList)
                model.Categories.FirstOrDefault(predicate => predicate.Key.Id == subCategory.CategoryId).Value.Add(subCategory);

            return View(model);
        }
    }
}
