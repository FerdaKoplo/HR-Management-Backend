namespace hr_management_backend.DTOs.Attendance
{
    public class UpdateAttendanceDTO
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
