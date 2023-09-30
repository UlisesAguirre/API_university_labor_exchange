using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Implementations
{
    public class Repository : IRepository
    {
        internal readonly UniversityLaborExchangeContext _context;

        public Repository (UniversityLaborExchangeContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
