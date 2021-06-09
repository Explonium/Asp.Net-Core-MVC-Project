using Microsoft.AspNetCore.Mvc;
using Mvc_Project_Client.Models;
using Mvc_Project_Client.Services;
using Mvc_Project_Client.ViewModels;
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
            var catList = await _requestService.GetList<Category>("Categories");
            var subList = await _requestService.GetList<SubCategory>("Subcategories");

            var model = new CategoriesViewModel();

            foreach (var category in catList)
                model.Categories.Add(category, new List<SubCategory>());

            foreach (var subCategory in subList)
                model.Categories.FirstOrDefault(predicate => predicate.Key.Id == subCategory.CategoryId).Value.Add(subCategory);

            return View(model);
        }
    }
}
