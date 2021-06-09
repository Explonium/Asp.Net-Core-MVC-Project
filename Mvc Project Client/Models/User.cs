using System;

namespace Mvc_Project_Client.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.6.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CountryId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalIndex { get; set; }
    }
}
