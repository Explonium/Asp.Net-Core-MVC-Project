using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class CartedProduct
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductVariantId { get; set; }
        public Guid DelivetyRouteId { get; set; }
        public int amount { get; set; }
    }
}
