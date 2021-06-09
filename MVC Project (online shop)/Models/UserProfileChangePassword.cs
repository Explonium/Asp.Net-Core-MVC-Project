using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserProfileChangePassword
    {
        [Required(ErrorMessage = "Old password is required")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New password is required")]
        [MinLength(6, ErrorMessage = "Minimum password length is 6")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords doesn't match")]
        public string ConfirmNewPassword { get; set; }
    }
}
