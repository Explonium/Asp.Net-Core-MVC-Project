using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class Supply
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductVariantId { get; set; }
        public Guid StorageId { get; set; }
        public int amount { get; set; }
        public DateTime DateTime { get; set; }

        // Relations

        [ForeignKey("ProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }

        [ForeignKey("StorageId")]
        public virtual Storage Storage { get; set; }
    }
}
