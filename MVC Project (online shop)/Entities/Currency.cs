using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class Currency
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Symbol { get; set; }
        public float Cost { get; set; }

        // Relations

        [InverseProperty("DefaultCurrency")]
        public ICollection<Country> Countries { get; set; }
    }
}
