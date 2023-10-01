using API_university_labor_exchange.Models.Student;
using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_university_labor_exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
       private readonly IStudentService _studentService;
       public StudentController(IStudentService studentService) 
       {
            _studentService = studentService;
       }

        [HttpGet("GetAllStudents")]
        public ActionResult<ICollection<ReadAllStudentDTO>> GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("GetStudent")]
        public ActionResult<ReadAllStudentDTO> GetStudent(int id)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }


    }
}
