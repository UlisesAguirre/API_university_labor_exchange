using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.CareerDTOs;
using AutoMapper;

namespace API_university_labor_exchange.Profiles
{
    public class CareerProfile : Profile
    {
        public CareerProfile() 
        {
            CreateMap<CreateCareerDTO, Career>();
            CreateMap<Career, ReadCareerDTO>();
            CreateMap<Career, ReadCareersForFormDTO>();

        }
    }
}
