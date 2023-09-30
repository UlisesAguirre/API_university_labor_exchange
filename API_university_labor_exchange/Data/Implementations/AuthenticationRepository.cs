using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Implementations
{
    public class AuthenticationRepository : Repository, IAuthenticationRepository
    {
      
        public AuthenticationRepository (UniversityLaborExchangeContext context) : base(context) { }

        public User? ValidateUser(string email, string password) {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
