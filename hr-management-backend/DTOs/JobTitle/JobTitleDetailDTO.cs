using hr_management_backend.DTOs.Employee;
using hr_management_backend.DTOs.Recruitment;

namespace hr_management_backend.DTOs.JobTitle
{
    public class JobTitleDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // Optional: include employee info if needed
        public ICollection<EmployeeDTO>? Employees { get; set; }
        public ICollection<RecruitmentDTO>? Recruitments { get; set; }
    }
}
