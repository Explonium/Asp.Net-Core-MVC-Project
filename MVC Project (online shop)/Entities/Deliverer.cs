using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class Deliverer
    {
        [Key]
        public string Username { get; set; }

        // Relations

        [ForeignKey("Username")]
        public User User { get; set; }
        public ICollection<DeliveryRoute> DeliveryRoutes { get; set; } = new List<DeliveryRoute>();
    }
}
