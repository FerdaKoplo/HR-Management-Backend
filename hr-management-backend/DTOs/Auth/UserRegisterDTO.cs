using hr_management_backend.Models;
using System.ComponentModel.DataAnnotations;

namespace hr_management_backend.DTOs.Auth
{
    public class UserRegisterDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format"), ]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
