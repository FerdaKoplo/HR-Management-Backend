using AutoMapper;
using hr_management_backend.DTOs.JobTitle;
using hr_management_backend.DTOs.Recruitment;
using hr_management_backend.Models;

namespace hr_management_backend.Profiles
{
    public class RecruitmentProfile : Profile
    {
        public RecruitmentProfile()
        {
            CreateMap<RecruitmentDTO, Recruitment>();
            CreateMap<RecruitmentDetailDTO, Recruitment>();

            CreateMap<Recruitment, RecruitmentDTO>();
            CreateMap<Recruitment, RecruitmentDetailDTO>();
        }
    }
}
