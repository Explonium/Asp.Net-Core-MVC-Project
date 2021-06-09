using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class ProductVariant
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid CurrencyId { get; set; }
        public float Cost { get; set; }
        public string Name { get; set; }

        // Relations

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }

        [InverseProperty("ProductVariant")]
        public virtual ICollection<Stock> Stocks { get; set; }

        [InverseProperty("ProductVariant")]
        public virtual ICollection<Supply> Supplies { get; set; }

        [InverseProperty("ProductVariant")]
        public virtual ICollection<CartedProduct> CartedProducts { get; set; }
    }
}
