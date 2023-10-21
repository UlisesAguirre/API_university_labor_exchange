using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.JobPositionDTOs.SkillsCareerListDto;
using API_university_labor_exchange.Models.SkillDTOs;
using AutoMapper;

namespace API_university_labor_exchange.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile() 
        {
            CreateMap<CreateSkillDTO, Skill>();
            CreateMap<Skill, CreateSkillDTO>();
            CreateMap<Skill, ReadSkillDTO>();
        }
        
    }
}
