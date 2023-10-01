using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_university_labor_exchange.Data.Implementations
{
    public class StudentRepository : Repository, IStudentRepository
    {
        public StudentRepository(UniversityLaborExchangeContext context) : base(context) { }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students;
        }
        public Student? GetStudent(int id)
        {
            return _context.Students.FirstOrDefault(s => s.IdUser == id);

        }
        public void UpdateStudent(Student student)
        {

        }
    }
}
