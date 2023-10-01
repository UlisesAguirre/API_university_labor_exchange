using API_university_labor_exchange.Models;
using API_university_labor_exchange.Models.StudentDTOs;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface IRegisterService
    {
        bool CreateStudent(CreateStudentDTO student);
    }
}
