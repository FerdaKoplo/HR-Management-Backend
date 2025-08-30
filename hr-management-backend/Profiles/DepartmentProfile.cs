using AutoMapper;
using hr_management_backend.DTOs.Department;
using hr_management_backend.DTOs.Employee;
using hr_management_backend.Models;

namespace hr_management_backend.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<CreateDepartmentDTO, Department>();
            CreateMap<UpdateDepartmentDTO, Department>();
            CreateMap<DepartmentDTO, Department>();
            CreateMap<DepartmentDetailDTO, Department>();

            CreateMap<Department, CreateDepartmentDTO>();
            CreateMap<Department, UpdateDepartmentDTO>();
            CreateMap<Department, DepartmentDTO>();
            CreateMap<Department, DepartmentDetailDTO>();
        }
    }
}
