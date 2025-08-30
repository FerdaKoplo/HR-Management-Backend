using AutoMapper;
using hr_management_backend.DTOs.Employee;
using hr_management_backend.DTOs.JobTitle;
using hr_management_backend.Models;

namespace hr_management_backend.Profiles
{
    public class JobTitleProfile : Profile
    {
        public JobTitleProfile()
        {
            CreateMap<CreateJobTitleDTO, JobTitle>();
            CreateMap<UpdateJobTitleDTO, JobTitle>();
            CreateMap<JobTitleDTO, JobTitle>();
            CreateMap<JobTitleDetailDTO, JobTitle>();

            
            CreateMap<JobTitle,  CreateJobTitleDTO>();
            CreateMap<JobTitle,  UpdateJobTitleDTO>();
            CreateMap<JobTitle, JobTitleDTO>();
            CreateMap<JobTitle, JobTitleDetailDTO>();
        }
    }
}
