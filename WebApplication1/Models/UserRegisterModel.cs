using System.ComponentModel.DataAnnotations;

namespace MvcProjectApi.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(6, ErrorMessage = "Minimum username length is 6")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Minimum password length is 6")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}
