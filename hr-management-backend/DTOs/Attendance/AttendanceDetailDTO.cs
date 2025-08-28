namespace hr_management_backend.DTOs.Attendance
{
    public class AttendanceDetailDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public bool Present { get; set; }
    }
}
