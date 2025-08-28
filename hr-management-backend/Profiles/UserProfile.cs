using AutoMapper;
using hr_management_backend.DTOs;
using hr_management_backend.DTOs.Auth;
using hr_management_backend.Models;

namespace hr_management_backend.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // map userRegisterDto to User
            CreateMap<UserRegisterDTO, User>();

            // map user to user dto for response 
            CreateMap<User, UserDTO>();
        }
    }
}
