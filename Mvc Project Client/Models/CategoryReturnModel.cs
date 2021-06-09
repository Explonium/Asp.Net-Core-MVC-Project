using Newtonsoft.Json;

namespace Mvc_Project_Client.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.6.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class CategoryReturnModel
    {
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Guid Id { get; set; }

        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("iconPath", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string IconPath { get; set; }


    }
}
