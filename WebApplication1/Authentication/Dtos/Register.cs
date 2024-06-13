using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Authentication.Dtos
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}
