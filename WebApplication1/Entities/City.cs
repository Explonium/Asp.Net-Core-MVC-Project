using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class City
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }

        // Relations

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [InverseProperty("City")]
        public virtual ICollection<User> Users { get; set; }

        [InverseProperty("City")]
        public virtual ICollection<Storage> Storages { get; set; }

        [InverseProperty("City")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
