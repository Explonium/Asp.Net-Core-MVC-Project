using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class DeliveryRoute
    {
        [Key]
        public Guid Id { get; set; }
        public string DelivererUsername { get; set; }
        public Guid CountryFromId { get; set; }
        public Guid CountryToId { get; set; }
        public Guid CurrencyId { get; set; }
        public int AvgDeliveryTime { get; set; }
        public float Cost { get; set; }
        public float maxMass { get; set; }
        public float maxLength { get; set; }
        public float maxSideSum { get; set; }

        /*=========== FOREIGN KEYS ===========*/

        [ForeignKey("DelivererUsername")]
        public virtual Deliverer Deliverer { get; set; }

        [ForeignKey("CountryFromId")]
        public virtual Country CountryFrom { get; set; }

        [ForeignKey("CountryToId")]
        public virtual Country CountryTo { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
    }
}
