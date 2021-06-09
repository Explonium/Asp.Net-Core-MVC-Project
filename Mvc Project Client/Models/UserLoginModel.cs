namespace Mvc_Project_Client.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.6.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class UserLoginModel
    {
        [Newtonsoft.Json.JsonProperty("username", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Username { get; set; }

        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Password { get; set; }


    }
}
