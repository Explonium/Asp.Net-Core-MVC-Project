using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class City
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }

        // Relations

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [InverseProperty("City")]
        public ICollection<User> Users { get; set; }

        [InverseProperty("City")]
        public ICollection<Storage> Storages { get; set; }
    }
}
