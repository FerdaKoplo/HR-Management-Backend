using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace hr_management_backend.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.Employee;
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Employee
    }
}
