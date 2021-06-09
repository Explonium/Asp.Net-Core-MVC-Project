using Mvc_Project_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Project_Client.ViewModels
{
    public class CountriesDatabaseViewModel
    {
        public ICollection<Country> Countries { get; set; }
        public Dictionary<string, string> Currencies { get; set; }
    }
}
