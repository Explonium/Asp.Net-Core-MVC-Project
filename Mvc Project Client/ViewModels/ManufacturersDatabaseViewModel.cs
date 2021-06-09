using Mvc_Project_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Project_Client.ViewModels
{
    public class ManufacturersDatabaseViewModel
    {
        public ICollection<Manufacturer> Manufacturers { get; set; }
    }
}
