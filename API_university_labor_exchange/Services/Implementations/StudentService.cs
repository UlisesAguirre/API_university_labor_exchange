using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.Student;
using API_university_labor_exchange.Models.StudentDTOs;
using API_university_labor_exchange.Services.Interfaces;
using AutoMapper;

namespace API_university_labor_exchange.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IUserRepository userRepository, IMapper mapper)
        {
            _studentRepository = studentRepository; 
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public ICollection<ReadAllStudentDTO> GetAllStudents()
        {
            var students = _studentRepository.GetAllStudents();
            return _mapper.Map<ICollection<ReadAllStudentDTO>>(students);
        }

        public ReadAllStudentDTO? GetStudent(int id)
        {
            var student = _studentRepository.GetStudent(id);
            return _mapper.Map<ReadAllStudentDTO>(student);
        }

        public void UpdateStudent(UpdateStudentDTO student)
        {
            throw new NotImplementedException();
        }

        public ReadProfileStudentDTO GetProfile(int id)
        {
            User userData = _userRepository.GetUserById(id);
            Student studentData = _studentRepository.GetStudent(id);

            ReadProfileStudentDTO studentProfile = _mapper.Map<ReadProfileStudentDTO>(studentData);

            studentProfile.Email = userData.Email;
            studentProfile.Username = userData.Username;

            return studentProfile;


        }
    }
}
