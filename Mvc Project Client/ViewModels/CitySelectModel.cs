using Mvc_Project_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Project_Client.ViewModels
{
    public class CitySelectModel
    {
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
    }
}
