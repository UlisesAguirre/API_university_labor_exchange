using API_university_labor_exchange.Models.JobPositionDTOs;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface IJobPositionService
    {
        public void AddJobPosition(CreateJobPositionDTO jobPositionDTO);
        List<ReadJobPositionDto> GetAllJobPosition();
        List<ReadJobPositionDto> GetAllInterships(List<ReadJobPositionDto> jobPosition);
        List<ReadJobPositionDto> GetAllJobs(List<ReadJobPositionDto> jobPosition);
    }
}
