using Mvc_Project_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Project_Client.ViewModels
{
    public class CategoriesDatabaseViewModel
    {
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
