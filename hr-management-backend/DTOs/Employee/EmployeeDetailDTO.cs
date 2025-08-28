namespace hr_management_backend.DTOs.Employee
{
    public class EmployeeDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Relations
        public string DepartmentName { get; set; }
        public string JobTitleName { get; set; }

        // User info
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
