using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Enums;
using API_university_labor_exchange.Models.Company;
using API_university_labor_exchange.Models.StudentDTOs;
using API_university_labor_exchange.Services.Interfaces;

namespace API_university_labor_exchange.Services.Implementations
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly IEncrypt _encrypt;

        public RegisterService(IRegisterRepository registerRepository, IEncrypt encrypt)
        {
            _registerRepository = registerRepository;
            _encrypt = encrypt;
        }
        public bool CreateStudent(CreateStudentDTO student)
        {
            string username = $"{student.Name} {student.LastName}";

            var hashedPassword = _encrypt.GetSHA256(student.Password);

            User userData = new User
            {
                Email = student.Email,
                Username = username,
                Password = hashedPassword,
                UserType = "student",
                State = State.SinAsignar,
            };

            Student StudentData = new Student
            {
                Name = student.Name,
                LastName = student.LastName,
                Legajo = student.Legajo,
            };

            bool newStudent = _registerRepository.CreateStudent(userData, StudentData);

            return newStudent;

        }

        public bool CreateCompany(CreateCompanyDTO company)
        {
            var hashedPassword = _encrypt.GetSHA256(company.Password);

            User userData = new User
            {
                Email = company.Email,
                Username = company.SocialReason,
                Password = hashedPassword,
                UserType = "company",
                State = State.SinAsignar
            };

            Company companyData = new Company
            {
                SocialReason = company.SocialReason,
                Cuit = company.Cuit,
            };

            bool newCompany = _registerRepository.CreateCompany(userData, companyData);

            return newCompany;

        }
    }
}
