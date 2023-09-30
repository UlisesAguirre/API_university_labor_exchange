using API_university_labor_exchange.Entities;
using AutoMapper;

namespace API_university_labor_exchange.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserDto, User>();
        }
    }
}
