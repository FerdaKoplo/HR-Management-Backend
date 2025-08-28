namespace hr_management_backend.DTOs.Salary
{
    public class CreateSalaryDTO
    {
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
