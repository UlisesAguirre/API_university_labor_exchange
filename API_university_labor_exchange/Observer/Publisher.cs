using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.Student;
using API_university_labor_exchange.Models.StudentDTOs;
using AutoMapper;

namespace API_university_labor_exchange.Observer
{
    public class Publisher
    {
        private readonly IStudentRepository _studentRepository;
        private readonly UniversityLaborExchangeContext _context;
        private readonly IMapper _mapper;

        public Publisher(IStudentRepository studentRepository, 
            UniversityLaborExchangeContext context, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _context = context;
            _mapper = mapper;
        }

        public void Subscribe(ISuscriber suscriber)
        {
            if (suscriber is UpdateStudentDTO){
                UpdateStudentDTO studentDTO = (UpdateStudentDTO)suscriber;

                Student student = _context.Students.FirstOrDefault(s => s.Legajo == studentDTO.Legajo);

                student.CareerSubscription = true;

                _context.SaveChanges();
            }
        }
        public void Unsubscribe(ISuscriber suscriber)
        {
            if (suscriber is UpdateStudentDTO)
            {
                UpdateStudentDTO studentDTO = (UpdateStudentDTO)suscriber;

                Student student = _context.Students.FirstOrDefault(s => s.Legajo == studentDTO.Legajo);

                student.CareerSubscription = false;

                _context.SaveChanges();
            }
        }

        //public void Notify(int idCareer)
        //{

        //    var students = _studentRepository.GetAllStudents();

        //    var suscribers = students
        //        .Where(s => s.CareerSubscription == true)
        //        .Where(s => s.IdCareer == idCareer)
        //        .ToList(); ;

        //    List<UpdateStudentDTO> suscribersDTO = _mapper.Map<List<UpdateStudentDTO>>(suscribers);

        //    foreach (var suscriber in suscribersDTO)
        //    {
        //        suscriber.Update();
        //    }

        //    _context.SaveChanges();
        //}
    }
}
