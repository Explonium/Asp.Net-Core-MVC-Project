using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Guid DefaultCurrencyId { get; set; }

        // Relations

        [ForeignKey("DefaultCurrencyId")]
        public virtual Currency DefaultCurrency { get; set; }
        public virtual ICollection<City> Cities { get; set; } = new List<City>();
        [InverseProperty("CountryFromId")]
        public virtual ICollection<DeliveryRoute> DeliveryRoutesFrom { get; set; } = new List<DeliveryRoute>();
        [InverseProperty("CountryToId")]
        public virtual ICollection<DeliveryRoute> DeliveryRoutesTo { get; set; } = new List<DeliveryRoute>();
    }
}
