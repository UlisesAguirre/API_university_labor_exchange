using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Implementations
{
    public class JobPositionRepository : Repository, IJobPositionRepository
    {
        public JobPositionRepository(UniversityLaborExchangeContext context) : base(context) { }

        public void AddJobPosition(JobPosition jobPosition)
        {
            _context.JobPositions.Add(jobPosition);
            _context.SaveChanges();
        }
    }
}
