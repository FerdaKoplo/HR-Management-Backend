using hr_management_backend.Models;

namespace hr_management_backend.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

        public int? EmployeeId { get; set; }
    }
}
