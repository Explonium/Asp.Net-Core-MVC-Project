using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Project_Client.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.6.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class IdentityUserOfString
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }

        [Newtonsoft.Json.JsonProperty("normalizedUserName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NormalizedUserName { get; set; }

        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty("normalizedEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NormalizedEmail { get; set; }

        [Newtonsoft.Json.JsonProperty("emailConfirmed", Required = Newtonsoft.Json.Required.Always)]
        public bool EmailConfirmed { get; set; }

        [Newtonsoft.Json.JsonProperty("passwordHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PasswordHash { get; set; }

        [Newtonsoft.Json.JsonProperty("securityStamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SecurityStamp { get; set; }

        [Newtonsoft.Json.JsonProperty("concurrencyStamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ConcurrencyStamp { get; set; }

        [Newtonsoft.Json.JsonProperty("phoneNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("phoneNumberConfirmed", Required = Newtonsoft.Json.Required.Always)]
        public bool PhoneNumberConfirmed { get; set; }

        [Newtonsoft.Json.JsonProperty("twoFactorEnabled", Required = Newtonsoft.Json.Required.Always)]
        public bool TwoFactorEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("lockoutEnd", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? LockoutEnd { get; set; }

        [Newtonsoft.Json.JsonProperty("lockoutEnabled", Required = Newtonsoft.Json.Required.Always)]
        public bool LockoutEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("accessFailedCount", Required = Newtonsoft.Json.Required.Always)]
        public int AccessFailedCount { get; set; }


    }
}
