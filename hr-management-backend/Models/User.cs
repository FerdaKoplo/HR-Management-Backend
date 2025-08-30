namespace hr_management_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
