using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Implementations
{
    public class RegisterRepository : Repository, IRegisterRepository
    {


        public RegisterRepository(UniversityLaborExchangeContext context) : base(context) { }


        public bool CreateStudent(User userData, Student studentData)
        {
            Student student = _context.Students.FirstOrDefault(s => s.Legajo == studentData.Legajo);

            User user = _context.Users.FirstOrDefault(u => u.Email == userData.Email);



            if (student == null)
            {
                if (user == null)
                {
                    _context.Users.Add(userData);
                    _context.SaveChanges();

                    int userId = userData.IdUser;

                    studentData.IdUser = userId;

                    _context.Students.Add(studentData);
                    _context.SaveChanges();

                    return true;

                }
                else
                {
                    //Ver como hacer el manejo de errores, en caso de que exista ya un usuario con el mismo legajo
                    //o con el mismo email
                    return false;
                }

            }
            else
            {
                return false;
            }

        }
    }
}
