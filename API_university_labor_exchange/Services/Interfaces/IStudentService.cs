using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.Student;
using API_university_labor_exchange.Models.StudentDTOs;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface IStudentService
    {
        public ICollection<ReadAllStudentDTO> GetAllStudents();
        public ReadAllStudentDTO? GetStudent(int id);
        public void UpdateStudent(UpdateStudentDTO student);
        ReadProfileStudentDTO GetProfile(int id);
    }
}
