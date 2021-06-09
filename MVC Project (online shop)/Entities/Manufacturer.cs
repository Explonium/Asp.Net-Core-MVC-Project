using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Manufacturer
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ManufacturerUri { get; set; }
        public string IconPath { get; set; }

        // Relations

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
