using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
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
        public virtual City City { get; set; }

        [ForeignKey("VendorUsername")]
        public virtual Vendor Vendor { get; set; }

        [InverseProperty("Storage")]
        public virtual ICollection<Stock> Stocks { get; set; }

        [InverseProperty("Storage")]
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
