using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.Student;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface IStudentService
    {
        public IEnumerable<ReadAllStudentDTO> GetAllStudents();
        public ReadAllStudentDTO? GetStudent(int id);
        public void UpdateStudent(UpdateStudentDTO student);
    }
}
