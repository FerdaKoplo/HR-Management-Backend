using hr_management_backend.Models;

namespace hr_management_backend.DTOs.Auth
{
    public class UserRegisterDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
