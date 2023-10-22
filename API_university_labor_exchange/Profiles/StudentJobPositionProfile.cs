using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.JobPositionDTOs;
using AutoMapper;

namespace API_university_labor_exchange.Profiles
{
    public class StudentJobPositionProfile : Profile
    {
       public StudentJobPositionProfile()
       {
            CreateMap<StudentsJobPosition, StudentsJobPositionDTO>();
       }
    }
}
