using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.SkillDTOs;
using AutoMapper;

namespace API_university_labor_exchange.Profiles
{
    public class StudentSkillsProfile : Profile
    {
        public StudentSkillsProfile() 
        {
            CreateMap<StudentSkillsDto, StudentsSkill>();
            CreateMap<StudentsSkill, StudentSkillsDto>();
            CreateMap<StudentsSkill, CreateStudentSkillsDTO>();
        }
    }
}
