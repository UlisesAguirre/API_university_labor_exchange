using API_university_labor_exchange.Models;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface IRegisterService
    {
        bool CreateStudent(CreateStudentDTO student);
    }
}
