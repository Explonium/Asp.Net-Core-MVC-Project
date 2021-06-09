using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class Waybill
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OrderId { get; set; }
        public Guid CurrencyId { get; set; }
        public float Cost { get; set; }

        // Relations

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
    }
}
