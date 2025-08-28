namespace hr_management_backend.DTOs.Evaluation
{
    public class EvaluationDetailDTO
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
    }
}
