using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
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

        [InverseProperty("Country")]
        public virtual ICollection<City> Cities { get; set; }

        [InverseProperty("CountryFrom")]
        public virtual ICollection<DeliveryRoute> DeliveryRoutesFrom { get; set; }

        [InverseProperty("CountryTo")]
        public virtual ICollection<DeliveryRoute> DeliveryRoutesTo { get; set; }

    }
}
