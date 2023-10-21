using API_university_labor_exchange.Models.JobPositionDTOs;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface IJobPositionService
    {
        public void AddJobPosition(CreateJobPositionDTO jobPositionDTO);
        ICollection<ReadJobPositionDto> GetAllJobPosition();
        ICollection<ReadJobPositionDto> GetAllInterships(ICollection<ReadJobPositionDto> jobPosition);
        ICollection<ReadJobPositionDto> GetAllJobs(ICollection<ReadJobPositionDto> jobPosition);
    }
}
