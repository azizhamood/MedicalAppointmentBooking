using System.ComponentModel.DataAnnotations;

namespace Share.DTO
{
    public class UserLoginDto
    {
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
