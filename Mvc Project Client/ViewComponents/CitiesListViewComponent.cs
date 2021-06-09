using Microsoft.AspNetCore.Mvc;
using Mvc_Project_Client.Models;
using Mvc_Project_Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Project_Client.ViewComponents
{
    public class CitiesListViewComponent : ViewComponent
    {
        private readonly IRequestService _requestService;

        public CitiesListViewComponent(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _requestService.GetList<CitiesListModel>("Cities");

            return View(list);
        }
    }
}
