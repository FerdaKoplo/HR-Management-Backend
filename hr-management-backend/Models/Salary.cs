
using System.ComponentModel.DataAnnotations.Schema;

namespace hr_management_backend.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public decimal Amount { get; set; }
        public DateTime EffectiveDate { get; set; }

        [NotMapped]
        public decimal Bonus => Amount * 0.1m; // 10% bonus
    }
}
