using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface IAuthenticationService
    {
        User ValidateUser(string email, string password);
    }
}
