using System;

namespace WebApplication1.Models
{
    public class UserProfilePersonalInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CityId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalIndex { get; set; }
    }
}
