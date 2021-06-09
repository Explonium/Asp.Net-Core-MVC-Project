using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class Manufacturer
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ManufacturerUri { get; set; }
        public string IconPath { get; set; }

        // Relations

        [InverseProperty("Manufacturer")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
