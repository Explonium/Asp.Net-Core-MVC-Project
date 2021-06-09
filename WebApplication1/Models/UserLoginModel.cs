using System.ComponentModel.DataAnnotations;

namespace MvcProjectApi.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Enter username or email")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }
    }
}
