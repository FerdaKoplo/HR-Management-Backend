namespace hr_management_backend.DTOs.Attendance
{
    public class AttendanceDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public bool Present { get; set; }
    }
}
