using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.JobPositionDTOs;
using API_university_labor_exchange.Models.JobPositionDTOs.SkillsCareerListDto;
using AutoMapper;

public class JobPositionProfile : Profile
{
    public JobPositionProfile()
    {
        CreateMap<CreateJobPositionDTO, JobPosition>();
        CreateMap<ReadJobPositionDto, JobPosition>();
        CreateMap<JobPosition, ReadJobPositionDto>();
        CreateMap<JobPosition, ReadJobPositionCompanyDTO>()
            .ForMember(dest => dest.JobPostionsSkills, opt => opt.MapFrom(src => src.JobPostionsSkills.Select(js => new SkillsListDTO
            {
                IdSkill = js.IdSkillNavigation.IdSkill,
                SkillName = js.IdSkillNavigation.SkillName
            })))
            .ForMember(dest => dest.JobPositionsCareers, opt => opt.MapFrom(src => src.JobPositionsCareers.Select(jc => new CareersListDTO
            {
                IdCareer = jc.IdCareerNavigation.IdCareer,
                Name = jc.IdCareerNavigation.Name
            })))
            .ForMember(dest => dest.StudentsJobPositions, opt => opt.MapFrom(src => src.StudentsJobPositions.Select(sj => new StudentsJobPositionDTO
            {
                IdJobPosition = sj.IdJobPosition,
                IdUser = sj.LegajoNavigation.IdUser,
                Name = sj.LegajoNavigation.Name,
                LastName = sj.LegajoNavigation.LastName,
                Email = sj.LegajoNavigation.IdUserNavigation.Email
            })));
    }

}

