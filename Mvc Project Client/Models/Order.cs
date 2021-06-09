using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public Guid DeliveryRouteId { get; set; }
        public Guid CurrencyId { get; set; }
    }
}
