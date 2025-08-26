namespace hr_management_backend.Models
{
    public class JobTitle
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Recruitment> Recruitments { get; set; } = new List<Recruitment>();

    }
}
