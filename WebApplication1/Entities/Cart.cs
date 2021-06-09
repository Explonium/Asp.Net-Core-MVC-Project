using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }

        // Relations

        [ForeignKey("Username")]
        public User User { get; set; }

        [InverseProperty("Cart")]
        public virtual ICollection<CartedProduct> CartedProducts { get; set; }
    }
}
