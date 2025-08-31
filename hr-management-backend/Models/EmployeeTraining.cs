namespace hr_management_backend.Models
{
    public class EmployeeTraining : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int TrainingId { get; set; }
        public Training Training { get; set; }

        // Extra fields
        public DateTime EnrolledAt { get; set; }
        public bool Completed { get; set; }
    }
}
