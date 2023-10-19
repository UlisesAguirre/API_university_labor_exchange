using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Interfaces
{
    public interface IJobPositionRepository : IRepository
    {
        public void AddJobPosition(JobPosition jobPosition);
        List<JobPosition> GetAllJobPosition();

    }
}
