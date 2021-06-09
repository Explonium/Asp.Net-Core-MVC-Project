using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string VendorUserName { get; set; }

        [ForeignKey("VendorUserName")]
        public Vendor Vendor { get; set; }

        public Guid SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public SubCategory SubCategory { get; set; }

        public Guid ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        public Manufacturer Manufacturer { get; set; }

        public string Tags { get; set; }
        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}
