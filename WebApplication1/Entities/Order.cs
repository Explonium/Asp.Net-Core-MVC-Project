using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public Guid DeliveryRouteId { get; set; }
        public Guid CurrencyId { get; set; }

        // Relations

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [InverseProperty("Order")]
        public virtual ICollection<OrderSupply> OrderSupplies { get; set; }

        [InverseProperty("Order")]
        public virtual ICollection<Dispute> Disputes { get; set; }

        [InverseProperty("Order")]
        public virtual ICollection<Waybill> Waybills { get; set; }

    }
}
