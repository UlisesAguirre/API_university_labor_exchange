using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.CompanyDTOs;
using API_university_labor_exchange.Models.StudentDTOs;
using AutoMapper;

namespace API_university_labor_exchange.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserDto, User>();

            CreateMap<User, ReadStudentsToAdmin>();
            CreateMap<ReadStudentsToAdmin, User>();
    
            CreateMap<User, ReadCompaniesToAdmin>();
            CreateMap<ReadCompaniesToAdmin, User>();
        }
    }
}
