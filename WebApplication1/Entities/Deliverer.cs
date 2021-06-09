using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class Deliverer
    {
        [Key]
        public string Username { get; set; }

        // Relations

        [ForeignKey("Username")]
        public virtual User User { get; set; }

        [InverseProperty("Deliverer")]
        public virtual ICollection<DeliveryRoute> DeliveryRoutes { get; set; }
    }
}
