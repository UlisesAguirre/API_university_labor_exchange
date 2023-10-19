using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.JobPositionDTOs;
using API_university_labor_exchange.Models.JobPositionDTOs.SkillsCareerListDto;
using API_university_labor_exchange.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_university_labor_exchange.Services.Implementations
{
    public class JobPositionService : IJobPositionService
    {
        private readonly IJobPositionRepository _jobPositionRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ICareerRepository _careerRepository;
        private readonly IMapper _mapper;

        public JobPositionService(IJobPositionRepository jobPositionRepository,
            ISkillRepository skillRepository, ICareerRepository careerRepository, IMapper mapper)
        {
            _jobPositionRepository = jobPositionRepository;
            _skillRepository = skillRepository;
            _careerRepository = careerRepository;
            _mapper = mapper;
        }

        public void AddJobPosition(CreateJobPositionDTO jobPositionDTO)
        {

            JobPosition newJobPosition = _mapper.Map<JobPosition>(jobPositionDTO);
            newJobPosition.JobPositionsCareers = _mapper.Map<List<JobPositionsCareer>>(jobPositionDTO.jobPositionCareer);
            newJobPosition.JobPostionsSkills = _mapper.Map<List<JobPostionsSkill>>(jobPositionDTO.jobPositionSkill);
            _jobPositionRepository.AddJobPosition(newJobPosition);
        }

        public List<ReadJobPositionDto> GetAllJobPosition()
        {
            List<JobPosition> allJobPosition = _jobPositionRepository.GetAllJobPosition();

            List<ReadJobPositionDto> allJobPositionDTO = _mapper.Map<List<ReadJobPositionDto>>(allJobPosition);

            foreach (var intership in allJobPositionDTO)
            {
                foreach(int idSkill in intership.JobPostionsSkills.Select(s => s.IdSkill))
                {
                    Skill skill = _skillRepository.GetSkill(idSkill);

                    if (skill != null)
                    {
                        intership.JobPostionsSkills.FirstOrDefault(s => s.IdSkill == idSkill).SkillName = skill.SkillName;
                    }
                }

                foreach(int idCareer in intership.JobPositionsCareers.Select(s => s.IdCarrer))
                {
                    Career career = _careerRepository.GetCareerBy(idCareer);
                    if (career != null)
                    {
                        intership.JobPositionsCareers.FirstOrDefault(s=> s.IdCarrer == idCareer).Name = career.Name;
                    }
                }
            }

            return allJobPositionDTO;
        }

        public List<ReadJobPositionDto> GetAllInterships(List<ReadJobPositionDto> jobPosition)
        {
            var allInterships = jobPosition.Where(j => j.JobType == JobType.Pasantía).ToList();

            return allInterships;
        }

        public List<ReadJobPositionDto> GetAllJobs(List<ReadJobPositionDto> jobPosition)
        {
            var allJobs = jobPosition.Where(j => j.JobType == JobType.Trabajo).ToList(); 

            return allJobs;
        }

    }
}
