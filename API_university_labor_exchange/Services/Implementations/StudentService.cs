using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models;
using API_university_labor_exchange.Models.SkillDTOs;
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

        public List<ReadStudentsToAdmin> GetStudentsForAdmin()

        {
            List<User> users = _userRepository.GetStudentsForAdmin();

            List<ReadStudentsToAdmin> students = _mapper.Map<List<ReadStudentsToAdmin>>(users);

            foreach (var student in students)
            {
                var studentData = _studentRepository.GetStudent(student.IdUser);
                if(studentData != null)
                    student.Legajo = studentData.Legajo;

            }

            return students;
        }

        public ReadAllStudentDTO? GetStudent(int id)
        {
            var student = _studentRepository.GetStudent(id);
            User userData = _userRepository.GetUserById(id);

            var UserStudent = _mapper.Map<ReadAllStudentDTO>(student);

            UserStudent.Email = userData.Email;
            UserStudent.Username = userData.Username;

            return UserStudent;
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

        public void UpdateStudent(UpdateStudentDTO student, int id)
        {
            Student? studentToUpdate = _studentRepository.GetStudent(id);
            User? userToUpdate = _userRepository.GetUserById(id);

            if (studentToUpdate != null && userToUpdate != null)
            {
                userToUpdate.Email = student.Email;
                userToUpdate.Username = student.Username;

                _mapper.Map(student, studentToUpdate);
                _studentRepository.UpdateStudent(studentToUpdate);
                _userRepository.UpdateUser(userToUpdate);

                _studentRepository.SaveChanges();

            }
        }

        public void UpdateSkills(List<StudentSkillsDto> skills, int id)
        {
            Student? studentToUpdate = _studentRepository.GetStudent(id);

            var skillList = _mapper.Map<List<StudentsSkill>>(skills);

            if (studentToUpdate != null)
            {
                foreach (var skill in skillList)
                {
                    if (skill.IdSkill != null)
                    {
                        _studentRepository.UpdateStudentsSkill(skill, id);
                    }
                }
            }

            _studentRepository.DeleteStudentsSkill(skillList, id);

        }

        public void AddCurriculum(IFormFile curriculum, int studentId)
        {
            Student? student = _studentRepository.GetStudent(studentId);

            if (student != null)
            {
                using var fileStream = curriculum.OpenReadStream(); //OpenReadStream() abre la request stream para leer el archivo
                byte[] bytes = new byte[curriculum.Length]; //declaro un array de bytes con la longitud requerida por el archivo
                fileStream.Read(bytes, 0, bytes.Length); // mappea los bytes del archivo y los guarda en el array bytes

                student.Curriculum = bytes;

                _studentRepository.UpdateStudent(student);
                _studentRepository.SaveChanges();
            }

        }

        public bool DeleteCurriculum(int id)
        {
            Student? student = _studentRepository.GetStudent(id);

            if (student != null)
            {
                student.Curriculum = null;
                if (_studentRepository.SaveChanges())
                    return true;
            }
            return false;
        }


        public Student GetCurriculum(int id)
        {
            return _studentRepository.GetStudent(id);
        }

        public void SetUserState(SetUserStateDTO user)
        {
            _userRepository.SetUserState(user);
        }
    }
}
