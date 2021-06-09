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
    public class DatalistViewComponent : ViewComponent
    {
        private readonly IRequestService _requestService;

         public DatalistViewComponent(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            ICollection<DataListModel> test = new List<DataListModel>();
            var list = (await _requestService.GetList<DataListModel>(id))
                .ToDictionary(x => x.Id, x => x.Name);


            return View(new DatalistViewModel { Id = id, List = list });
        }
    }
}
