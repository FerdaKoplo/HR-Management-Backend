namespace hr_management_backend.Models
{
    public class Department
    {
        public int Id { get; set; }          
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>(); // navigation property for department perspective
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }
    }
}
