using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models;
using API_university_labor_exchange.Models.SkillDTOs;
using API_university_labor_exchange.Models.Student;
using API_university_labor_exchange.Models.StudentDTOs;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface IStudentService
    {
        List<ReadStudentsToAdmin> GetStudentsForAdmin();
        public ReadAllStudentDTO? GetStudent(int id);
        public void UpdateStudent(UpdateStudentDTO student, int id);
        ReadProfileStudentDTO GetProfile(int id);
        void UpdateSkills(List<StudentSkillsDto> skills, int id);
        public void AddCurriculum(IFormFile curriculum, int studentId);
        public bool DeleteCurriculum(int id);
        public Student GetCurriculum(int id);
        void SetUserState(SetUserStateDTO user);
    }
}
