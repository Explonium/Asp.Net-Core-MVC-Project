using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class ProductVariant
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string Name { get; set; }
        public Guid CurrencyId { get; set; }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
        public float Cost { get; set; }
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    }
}
