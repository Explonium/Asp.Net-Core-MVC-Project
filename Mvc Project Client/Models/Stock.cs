using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class Stock
    {
        [Key]
        public Guid Id { get; set; }
        public Guid StorageId { get; set; }
        public Guid ProductVariantId { get; set; }
        public int Quantity { get; set; }
    }
}
