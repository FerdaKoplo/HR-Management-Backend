namespace hr_management_backend.Models
{
    public class Evaluation : BaseEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public string Comments { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
