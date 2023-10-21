using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.JobPositionDTOs;
using AutoMapper;

public class JobPositionProfile : Profile
{
    public JobPositionProfile()
    {
        CreateMap<CreateJobPositionDTO, JobPosition>();

        CreateMap<ReadJobPositionDto, JobPosition>();
        CreateMap<JobPosition, ReadJobPositionDto>();
    }
}
