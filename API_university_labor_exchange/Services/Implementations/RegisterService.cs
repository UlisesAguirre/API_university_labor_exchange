using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models;
using API_university_labor_exchange.Services.Interfaces;

namespace API_university_labor_exchange.Services.Implementations
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepository;

        public RegisterService(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }
        public bool CreateStudent(CreateStudentDTO student)
        {
            string username = $"{student.Name} {student.LastName}";

            User userData = new User
            {
                Email = student.Email,
                Username = username,
                Password = student.Password, //Aca habria que hacer logica para hashear el password
                UserType = "student"
            };

            Student StudentData = new Student
            {
                Name = student.Name,
                LastName = student.LastName,
                Legajo = student.Legajo,
                IdCarrer = -1
            };

            bool newStudent = _registerRepository.CreateStudent(userData, StudentData);

            return newStudent;

        }
    }
}
