namespace hr_management_backend.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; } // foreign key
        public int JobTitleId { get; set; }

        // relations

        public Department Department { get; set; } // navigation property for employee perspective
        public JobTitle JobTitle { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

        public ICollection<Salary> Salaries { get; set; } = new List<Salary>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<EmployeeTraining> EmployeeTrainings { get; set; } = new List<EmployeeTraining>();// navigation for employee training perspective
    }
}
