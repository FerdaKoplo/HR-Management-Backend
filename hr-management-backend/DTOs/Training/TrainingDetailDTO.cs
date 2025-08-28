using hr_management_backend.DTOs.Employee;

namespace hr_management_backend.DTOs.Training
{
    public class TrainingDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();
    }
}
