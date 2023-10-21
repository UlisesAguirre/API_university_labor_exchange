using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Enums;
using API_university_labor_exchange.Models.JobPositionDTOs;
using API_university_labor_exchange.Services.Interfaces;
using AutoMapper;

namespace API_university_labor_exchange.Services.Implementations
{
    public class JobPositionService : IJobPositionService
    {
        private readonly IJobPositionRepository _jobPositionRepository;
        private readonly IMapper _mapper;
       
        public JobPositionService(IJobPositionRepository jobPositionRepository, IMapper mapper)
        {
            _jobPositionRepository = jobPositionRepository;
            _mapper = mapper;
        }

        public void AddJobPosition(CreateJobPositionDTO jobPositionDTO)
        {

            JobPosition newJobPosition = _mapper.Map<JobPosition>(jobPositionDTO);
            newJobPosition.State = State.SinAsignar;
            newJobPosition.JobPositionsCareers = _mapper.Map<List<JobPositionsCareer>>(jobPositionDTO.jobPositionCareer);
            newJobPosition.JobPostionsSkills = _mapper.Map<List<JobPostionsSkill>>(jobPositionDTO.jobPositionSkill);
            _jobPositionRepository.AddJobPosition(newJobPosition);
        }
    }
}
