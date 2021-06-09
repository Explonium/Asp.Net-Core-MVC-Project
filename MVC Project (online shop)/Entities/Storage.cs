using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class Storage
    {
        [Key]
        public Guid Id { get; set; }
        public string VendorUsername { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }

        // Relations

        [ForeignKey("CityId")]
        public City City { get; set; }

        [ForeignKey("VendorUsername")]
        public Vendor Vendor { get; set; }
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    }
}
