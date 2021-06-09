using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class Storage
    {
        [Key]
        public Guid Id { get; set; }
        public string VendorUsername { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }
    }
}
