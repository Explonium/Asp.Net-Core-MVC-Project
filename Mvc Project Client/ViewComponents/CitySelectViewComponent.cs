using Microsoft.AspNetCore.Mvc;
using Mvc_Project_Client.Models;
using Mvc_Project_Client.Services;
using Mvc_Project_Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Project_Client.ViewComponents
{
    public class CitySelectViewComponent : ViewComponent
    {
        private readonly IRequestService _requestService;

        public CitySelectViewComponent(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? CountryId, Guid? CityId)
        {
            return View(new CitySelectModel { CountryId = CountryId, CityId = CityId });
        }
    }
}
