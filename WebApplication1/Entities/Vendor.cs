using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class Vendor
    {
        [Key]
        public string Username { get; set; }
        public string CompanyName { get; set; }

        // Relations

        [ForeignKey("Username")]
        public virtual User User { get; set; }

        [InverseProperty("Vendor")]
        public virtual ICollection<Storage> Storages { get; set; }

        [InverseProperty("Vendor")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
