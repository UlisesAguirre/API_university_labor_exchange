using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.Student;
using API_university_labor_exchange.Models.StudentDTOs;

namespace API_university_labor_exchange.Observer
{
    public class Publisher
    {
        private readonly IStudentRepository _studentRepository;
        private readonly UniversityLaborExchangeContext _context;

        public Publisher(IStudentRepository studentRepository, UniversityLaborExchangeContext context)
        {
            _studentRepository = studentRepository;
            _context = context;
        }

        public void Subscribe(ISuscriber suscriber)
        {
            if (suscriber is ReadAllStudentDTO){
                ReadAllStudentDTO studentDTO = (ReadAllStudentDTO)suscriber;

                Student student = _context.Students.FirstOrDefault(s => s.Legajo == studentDTO.Legajo);
                student.
            }
        }
        public void Unsubscribe(ISuscriber suscriber)
        {
            suscribers.Remove(suscriber);
        }

        public void Notify(string message)
        {

            var students = _studentRepository.GetAllStudents();

            var suscriberss = students.Where(s => s.Address == "true"); //AGREGAR COLUMNA EN BD Y ARREGLAR

            foreach (var suscriber in suscriberss)
            {
                suscriber.Update();
            }
        }
    }
}
