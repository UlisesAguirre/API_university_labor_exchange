using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(UniversityLaborExchangeContext context) : base(context) { }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.IdUser == id);
        }

    }
}
