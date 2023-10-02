using API_university_labor_exchange.Data.Implementations;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.Student;

namespace API_university_labor_exchange.Data.Interfaces
{
    public interface IStudentRepository : IRepository
    {
        public IEnumerable<Student> GetAllStudents();
        public Student? GetStudent(int id);
        public void UpdateStudent (Student student);
    }
}
