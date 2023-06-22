using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Share.DTO
{
    public class UserRegisterDto
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, PasswordPropertyText]
        public string Password { get; set; }
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
