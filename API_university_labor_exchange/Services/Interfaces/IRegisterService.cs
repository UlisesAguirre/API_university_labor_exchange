using API_university_labor_exchange.Models.Company;
using API_university_labor_exchange.Models.StudentDTOs;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface IRegisterService
    {
        bool CreateStudent(CreateStudentDTO student);
        bool CreateCompany(CreateCompanyDTO company);
    }
}
