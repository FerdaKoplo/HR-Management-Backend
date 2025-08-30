using AutoMapper;
using hr_management_backend.DTOs.JobTitle;
using hr_management_backend.DTOs.Salary;
using hr_management_backend.Models;

namespace hr_management_backend.Profiles
{
    public class SalaryProfile : Profile
    {
        public SalaryProfile()
        {
            CreateMap<CreateSalaryDTO, Salary>();
            CreateMap<UpdateSalaryDTO, Salary>();
            CreateMap<SalaryDTO, Salary>();
            CreateMap<SalaryDetailDTO, Salary>();

            CreateMap<Salary, UpdateSalaryDTO>();
            CreateMap<Salary, CreateSalaryDTO>();
            CreateMap<Salary, SalaryDTO>();
            CreateMap<Salary, SalaryDetailDTO>();
        }
    }
}
