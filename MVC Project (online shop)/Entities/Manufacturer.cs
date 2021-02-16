using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project__online_shop_.Entities
{
    public class Manufacturer
    {
        [Key]
        public Guid Id { get; set; }

        public string ManufacturerUri { get; set; }

        public string IconPath { get; set; }
    }
}
