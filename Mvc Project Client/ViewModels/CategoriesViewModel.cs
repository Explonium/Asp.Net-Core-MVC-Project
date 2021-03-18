using Mvc_Project_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Project_Client.ViewModels
{
    public class CategoriesViewModel
    {
        public Dictionary<CategoryReturnModel, List<SubCategoryReturnModel>> Categories { get; set; } = 
            new Dictionary<CategoryReturnModel, List<SubCategoryReturnModel>>();
    }
}
