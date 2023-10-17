using API_university_labor_exchange.Models.JobPositionDTOs;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface IJobPositionService
    {
        public void AddJobPosition(CreateJobPositionDTO jobPositionDTO);
    }
}
