using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Interfaces
{
    public interface IAuthenticationRepository
    {
        User? ValidateUser(string email, string password);
    }
}
