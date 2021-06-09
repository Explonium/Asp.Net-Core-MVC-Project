using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class OrderSupply
    {
        [Key]
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public Guid OrderId { get; set; }
        public int amount { get; set; }
    }
}
