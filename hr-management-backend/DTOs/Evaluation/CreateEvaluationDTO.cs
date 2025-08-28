namespace hr_management_backend.DTOs.Evaluation
{
    public class CreateEvaluationDTO
    {
        public int EmployeeId { get; set; }
        public string Comments { get; set; }
        public int Score { get; set; }
    }
}
