using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid ManufacturerId { get; set; }
        public string Name { get; set; }
        public string VendorUserName { get; set; }
        public string Tags { get; set; }

        // Relations

        [ForeignKey("VendorUserName")]
        public virtual Vendor Vendor { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }

        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
