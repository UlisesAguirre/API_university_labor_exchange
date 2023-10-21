using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models;

namespace API_university_labor_exchange.Data.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(UniversityLaborExchangeContext context) : base(context) { }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.IdUser == id);
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<User> GetStudentsForAdmin()
        {
            return _context.Users.Where(u => u.UserType == "student").ToList(); 
        }

        public List<User> GetCompaniesForAdmin()
        {
            return _context.Users.Where(u => u.UserType == "company").ToList();
        }

        public void SetUserState(SetUserStateDTO user)
        {
            var findedUser = _context.Users.FirstOrDefault(u => u.IdUser == user.IdUser);

            if (findedUser != null)
            {
                findedUser.State = user.State;
            }

            _context.SaveChanges();

        }
    }
}

