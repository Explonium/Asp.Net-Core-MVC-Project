using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
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
    }
}
