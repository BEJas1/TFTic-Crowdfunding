using System.ComponentModel.DataAnnotations;

namespace API.Crowdfunding.Models
{
    public class UserRegister
    {
        [Required]
        [EmailAddress]
        [MaxLength(386)]
        [MinLength(1)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(32)]
        [MinLength(6)]
        public string? Password { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string? LastName { get; set; }
    }
}
