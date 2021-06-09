using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class Vendor
    {
        [Key]
        public string Username { get; set; }

        [ForeignKey("Username")]
        public User User { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Storage> Storages { get; set; } = new List<Storage>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
