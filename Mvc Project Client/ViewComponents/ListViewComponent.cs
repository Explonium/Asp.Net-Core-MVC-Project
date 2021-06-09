using Microsoft.AspNetCore.Mvc;
using Mvc_Project_Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Project_Client.ViewComponents
{
    public class ListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string list, string placeholder, string name)
        {
            return View(new ListViewModel { List = list, Name = name, Placeholder = placeholder });
        }
    }
}
