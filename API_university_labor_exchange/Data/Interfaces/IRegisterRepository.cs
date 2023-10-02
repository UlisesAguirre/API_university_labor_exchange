using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Interfaces
{
    public interface IRegisterRepository
    {
        bool CreateStudent(User newUser, Student newStudent);

        bool CreateCompany(User newUser, Company newCompany);
    }
}
