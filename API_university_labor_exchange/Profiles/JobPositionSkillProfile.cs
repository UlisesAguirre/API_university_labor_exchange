using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.JobPositionDTOs;
using API_university_labor_exchange.Models.JobPositionDTOs.SkillsCareerListDto;
using AutoMapper;

namespace API_university_labor_exchange.Profiles
{
    public class JobPositionSkillProfile : Profile
    {
        public JobPositionSkillProfile() 
        {
            CreateMap<JobPositionSkillDTO, JobPostionsSkill>();

            CreateMap<SkillsListDTO, JobPostionsSkill>();
            CreateMap<JobPostionsSkill, SkillsListDTO>();
        }
    }
}
