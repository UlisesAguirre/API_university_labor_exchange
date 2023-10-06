using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API_university_labor_exchange.Data.Implementations
{
    public class StudentRepository : Repository, IStudentRepository
    {
        public StudentRepository(UniversityLaborExchangeContext context) : base(context) { }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.Include(s=> s.StudentsSkills).ToList();
        }

        public Student? GetStudent(int id)
        {
            return _context.Students.Include(s => s.StudentsSkills)
                .FirstOrDefault(s => s.IdUser == id);
        }

        public void UpdateStudent(Student student)
        {
 
            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void AddStudentsSkill(StudentsSkill studentSkill)
        {
            _context.StudentsSkills.Add(studentSkill);
        }
    }
}
