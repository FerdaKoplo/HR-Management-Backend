using hr_management_backend.DTOs.Employee;

namespace hr_management_backend.DTOs.Department
{
    public class DepartmentDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Optional: include related entities
        public EmployeeDTO? Manager { get; set; } // Manager info
        public ICollection<EmployeeDTO>? Employees { get; set; }
    }
}
