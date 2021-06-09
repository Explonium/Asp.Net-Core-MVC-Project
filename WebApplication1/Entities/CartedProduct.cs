using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class CartedProduct
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductVariantId { get; set; }
        public Guid DelivetyRouteId { get; set; }
        public int amount { get; set; }

        // Relations

        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }

        [ForeignKey("ProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }

        [ForeignKey("DelivetyRouteId")]
        public virtual DeliveryRoute DeliveryRoute { get; set; }
    }
}
