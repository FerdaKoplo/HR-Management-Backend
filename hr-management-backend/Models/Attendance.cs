using System.ComponentModel.DataAnnotations.Schema;


namespace hr_management_backend.Models
{
    public class Attendance : BaseEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime Date { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        [NotMapped]
        public bool Present => CheckIn.HasValue;
    }
}
