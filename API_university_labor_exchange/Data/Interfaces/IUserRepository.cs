using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models;

namespace API_university_labor_exchange.Data.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        public void UpdateUser(User user);
        List<User> GetStudentsForAdmin();
        List<User> GetCompaniesForAdmin();
        void SetUserState(SetUserStateDTO user);
    }
}
