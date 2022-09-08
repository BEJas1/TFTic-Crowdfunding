using System.ComponentModel.DataAnnotations;

namespace API.Crowdfunding.Models
{
    public class UserLogin
    {
        [Required]
        [MaxLength(386)]
        [MinLength(1)]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MaxLength(32)]
        [MinLength(6)]
        public string? Password { get; set; }

    }
}
