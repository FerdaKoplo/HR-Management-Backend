using hr_management_backend.DTOs.Employee;

namespace hr_management_backend.DTOs.Salary
{
    public class SalaryDetailDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Bonus { get; set; } 
        public DateTime EffectiveDate { get; set; }

        public EmployeeDTO Employee { get; set; }
    }
}
