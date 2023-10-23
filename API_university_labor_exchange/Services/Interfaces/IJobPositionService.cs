using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.JobPositionDTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface IJobPositionService
    {
        public void AddJobPosition(CreateJobPositionDTO jobPositionDTO);
        ICollection<ReadJobPositionDto> GetAllJobPosition();
        ICollection<ReadJobPositionDto> GetAllInterships(ICollection<ReadJobPositionDto> jobPosition);
        ICollection<ReadJobPositionDto> GetAllJobs(ICollection<ReadJobPositionDto> jobPosition);
        public ICollection<ReadJobPositionCompanyDTO> GetCompanyJobPositions(string idCompany);
        public ICollection<ReadJobPositionCompanyDTO> GetJobPosition();
        public void AddStudentJobPosition(string legajo, int idJobPosition);

    }
}
