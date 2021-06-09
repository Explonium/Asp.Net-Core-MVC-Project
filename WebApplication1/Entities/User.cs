using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CountryId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalIndex { get; set; }

        // Relations

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [InverseProperty("User")]
        public virtual Vendor Vendor { get; set; }

        [InverseProperty("User")]
        public virtual Deliverer Deliverer { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<ChatMember> ChatMembers { get; set; }
    }
}
