using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class OrderSupply
    {
        [Key]
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public Guid OrderId { get; set; }
        public int amount { get; set; }

        // Relations

        [ForeignKey("StockId")]
        public virtual Stock Stock { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}
