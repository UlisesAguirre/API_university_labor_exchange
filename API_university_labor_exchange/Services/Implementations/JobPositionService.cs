using API_university_labor_exchange.Data.Implementations;
using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Enums;
using API_university_labor_exchange.Models;
using API_university_labor_exchange.Models.JobPositionDTOs;
using API_university_labor_exchange.Models.JobPositionDTOs.SkillsCareerListDto;
using API_university_labor_exchange.Observer;
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
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly Publisher _publisher;

        public JobPositionService(IJobPositionRepository jobPositionRepository,
            ISkillRepository skillRepository, ICareerRepository careerRepository,
            ICompanyRepository companyRepository, IMapper mapper, Publisher publisher)
        {
            _jobPositionRepository = jobPositionRepository;
            _skillRepository = skillRepository;
            _careerRepository = careerRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
            _publisher = publisher;
        }

        public void AddJobPosition(CreateJobPositionDTO jobPositionDTO)
        {

            JobPosition newJobPosition = _mapper.Map<JobPosition>(jobPositionDTO);
            newJobPosition.State = newJobPosition.JobType == "Pasantia" ?  State.SinAsignar : State.Habilitado;
            newJobPosition.JobPositionsCareers = _mapper.Map<List<JobPositionsCareer>>(jobPositionDTO.jobPositionCareer);
            newJobPosition.JobPostionsSkills = _mapper.Map<List<JobPostionsSkill>>(jobPositionDTO.jobPositionSkill);
            _jobPositionRepository.AddJobPosition(newJobPosition);

            foreach (JobPositionCareerDTO career in jobPositionDTO.jobPositionCareer)
            {
                _publisher.Notify(career.IdCareer);
            }
        }

        public ICollection<ReadJobPositionDto> GetAllJobPosition()
        {
            ICollection<JobPosition> allJobPosition = _jobPositionRepository.GetAllJobPosition();

            ICollection<ReadJobPositionDto> allJobPositionDTO = _mapper.Map<ICollection<ReadJobPositionDto>>(allJobPosition);

            foreach (var intership in allJobPositionDTO)
            {
                foreach (int idSkill in intership.JobPostionsSkills.Select(s => s.IdSkill))
                {
                    Skill skill = _skillRepository.GetSkill(idSkill);

                    if (skill != null)
                    {
                        intership.JobPostionsSkills.FirstOrDefault(s => s.IdSkill == idSkill).SkillName = skill.SkillName;
                    }
                }

                foreach (int idCareer in intership.JobPositionsCareers.Select(s => s.IdCareer))
                {
                    Career career = _careerRepository.GetCareerBy(idCareer);
                    if (career != null)
                    {
                        intership.JobPositionsCareers.FirstOrDefault(s => s.IdCareer == idCareer).Name = career.Name;
                    }
                }

                Company company = _companyRepository.GetCompanyByCUIT(intership.IdCompany);

                intership.CompanyName = company.SocialReason;
            }

            return allJobPositionDTO;
        }

        public ICollection<ReadJobPositionDto> GetAllInterships(ICollection<ReadJobPositionDto> jobPosition)
        {
            var allInterships = jobPosition.Where(j => j.JobType == "Pasantia").ToList();

            return allInterships;
        }

        public ICollection<ReadJobPositionDto> GetAllJobs(ICollection<ReadJobPositionDto> jobPosition)
        {
            var allJobs = jobPosition.Where(j => j.JobType == "Trabajo").ToList();

            return allJobs;
        }


        public ICollection<ReadJobPositionCompanyDTO> GetCompanyJobPositions(string idCompany)
        {
            var jobPosition = _jobPositionRepository.GetCompanyJobPositions(idCompany);

            var jobPositionDto = _mapper.Map<ICollection<ReadJobPositionCompanyDTO>>(jobPosition);

            return jobPositionDto;

        }

        public ICollection<ReadJobPositionDto> GetJobPosition(string legajo)
        {
            ICollection<JobPosition> allJobPosition = _jobPositionRepository.GetJobPositions();

            ICollection<ReadJobPositionDto> allJobPositionDTO = _mapper.Map<ICollection<ReadJobPositionDto>>(allJobPosition);

            foreach (var intership in allJobPositionDTO)
            {
                    List<StudentsListDTO> filteredStudents = new List<StudentsListDTO>();

                    foreach (StudentsListDTO studentItem in intership.StudentsJobPositions)
                    {

                        if (studentItem.Legajo == legajo)
                        {
                            filteredStudents.Add(studentItem);
                        }
                    }

                    intership.StudentsJobPositions = filteredStudents;

                foreach (int idSkill in intership.JobPostionsSkills.Select(s => s.IdSkill))
                {
                    Skill skill = _skillRepository.GetSkill(idSkill);

                    if (skill != null)
                    {
                        intership.JobPostionsSkills.FirstOrDefault(s => s.IdSkill == idSkill).SkillName = skill.SkillName;
                    }
                }

                foreach (int idCareer in intership.JobPositionsCareers.Select(s => s.IdCareer))
                {
                    Career career = _careerRepository.GetCareerBy(idCareer);
                    if (career != null)
                    {
                        intership.JobPositionsCareers.FirstOrDefault(s => s.IdCareer == idCareer).Name = career.Name;
                    }
                }

                Company company = _companyRepository.GetCompanyByCUIT(intership.IdCompany);

                intership.CompanyName = company.SocialReason;
            }

            return allJobPositionDTO;
        }

        public void SetJobPositionState(SetJobPositionStateDTO jobPosition)
        {
            _jobPositionRepository.SetJobPositionState(jobPosition);
        }

        public void AddStudentJobPosition(string legajo, int idJobPosition)
        {
            StudentsJobPosition newStudentJobPosition = new StudentsJobPosition();

            newStudentJobPosition.Legajo = legajo;
            newStudentJobPosition.IdJobPosition = idJobPosition;


            _jobPositionRepository.AddStudentJobPosition(newStudentJobPosition);

        }

    }
}
