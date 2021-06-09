using Mvc_Project_Client.Models;
using System.Collections.Generic;

namespace Mvc_Project_Client.ViewModels
{
    public class CategoriesViewModel
    {
        public Dictionary<Category, List<SubCategory>> Categories { get; set; } =
            new Dictionary<Category, List<SubCategory>>();
    }
}
