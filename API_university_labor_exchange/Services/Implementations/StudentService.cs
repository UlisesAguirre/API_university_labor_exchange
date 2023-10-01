using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Models.Student;
using API_university_labor_exchange.Services.Interfaces;
using AutoMapper;

namespace API_university_labor_exchange.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository; 
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
    }
}
