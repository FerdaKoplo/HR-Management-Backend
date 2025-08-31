namespace hr_management_backend.Models
{
    public class Training : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<EmployeeTraining> EmployeeTrainings { get; set; } = new List<EmployeeTraining>();
    }
}
