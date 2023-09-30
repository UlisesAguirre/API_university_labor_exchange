using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Services.Interfaces;

namespace API_university_labor_exchange.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository authentication)
        {
            _authenticationRepository = authentication;
        }

        public User ValidateUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            return _authenticationRepository.ValidateUser(email, password);
        }
    }
}
