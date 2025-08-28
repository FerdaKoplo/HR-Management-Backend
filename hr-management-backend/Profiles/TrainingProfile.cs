using AutoMapper;
using hr_management_backend.DTOs.Attendance;
using hr_management_backend.DTOs.Training;
using hr_management_backend.Models;

namespace hr_management_backend.Profiles
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<TrainingDTO, Training>();
            CreateMap<TrainingDetailDTO, Training>();

            CreateMap<Training, TrainingDTO>();
            CreateMap<Training, TrainingDetailDTO>();
        }
    }
}
