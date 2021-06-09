using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class Supply
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductVariantId { get; set; }
        public Guid StorageId { get; set; }
        public int amount { get; set; }
        public DateTime DateTime { get; set; }
    }
}
