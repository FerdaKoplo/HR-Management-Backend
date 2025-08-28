using AutoMapper;
using hr_management_backend.DTOs.Employee;
using hr_management_backend.Models;

namespace hr_management_backend.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // map employee dto to employee
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<EmployeeDetailDTO, Employee>();

            // amp employee to dto for response
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Employee , EmployeeDetailDTO>();
        }
    }
}
