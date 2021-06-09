using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
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
        public virtual ICollection<Country> Countries { get; set; }

        [InverseProperty("Currency")]
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }

        [InverseProperty("Currency")]
        public virtual ICollection<Waybill> Waybills { get; set; }
    }
}
