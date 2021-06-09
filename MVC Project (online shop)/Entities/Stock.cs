using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class Stock
    {
        [Key]
        public Guid Id { get; set; }
        public Guid StorageId { get; set; }

        [ForeignKey("StorageId")]
        public Storage Storage { get; set; }
        public Guid ProductVariantId { get; set; }

        [ForeignKey("ProductVariantId")]
        public ProductVariant ProductVariant { get; set; }
        public int Quantity { get; set; }
    }
}
