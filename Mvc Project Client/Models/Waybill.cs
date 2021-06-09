using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class Waybill
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OrderId { get; set; }
        public Guid CurrencyId { get; set; }
        public float Cost { get; set; }
    }
}
