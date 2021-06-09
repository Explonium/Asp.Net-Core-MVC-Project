using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CityId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalIndex { get; set; }

        // Relations

        [ForeignKey("CityId")]
        public City City { get; set; }
        public Vendor Vendor { get; set; }
        public Deliverer Deliverer { get; set; }
        public ICollection<ChatMember> ChatMembers { get; set; } = new List<ChatMember>();
    }
}
