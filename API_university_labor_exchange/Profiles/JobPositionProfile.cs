using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.JobPositionDTOs;
using AutoMapper;

namespace API_university_labor_exchange.Profiles
{
    public class JobPositionProfile: Profile 
    {
        public JobPositionProfile ()
        { 
            CreateMap<CreateJobPositionDTO, JobPosition>();
        }
}
}
