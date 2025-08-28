using AutoMapper;
using hr_management_backend.DTOs.Attendance;
using hr_management_backend.DTOs.Department;
using hr_management_backend.Models;

namespace hr_management_backend.Profiles
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            CreateMap<AttendanceDTO, Attendance>();
            CreateMap<AttendanceDetailDTO, Attendance>();

            CreateMap<Attendance, AttendanceDTO>();
            CreateMap<Attendance, AttendanceDetailDTO>();
        }
    }
}
