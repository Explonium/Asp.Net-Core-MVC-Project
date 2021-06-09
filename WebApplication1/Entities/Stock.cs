using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class Stock
    {
        [Key]
        public Guid Id { get; set; }
        public Guid StorageId { get; set; }
        public Guid ProductVariantId { get; set; }
        public int Quantity { get; set; }

        // Relations

        [ForeignKey("StorageId")]
        public virtual Storage Storage { get; set; }

        [ForeignKey("ProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }

        [InverseProperty("Stock")]
        public virtual ICollection<OrderSupply> OrderSupplies { get; set; }
    }
}
