using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        public void UpdateUser(User user);
    }
}
