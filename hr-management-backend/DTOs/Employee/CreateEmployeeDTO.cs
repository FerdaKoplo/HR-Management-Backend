namespace hr_management_backend.DTOs.Employee
{
    public class CreateEmployeeDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public int DepartmentId { get; set; }
        public int JobTitleId { get; set; }
    }
}
