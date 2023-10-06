using API_university_labor_exchange.Models;
using API_university_labor_exchange.Models.Company;
using API_university_labor_exchange.Models.Student;
using API_university_labor_exchange.Models.StudentDTOs;
using API_university_labor_exchange.Services.Implementations;
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

        [HttpGet("GetStudent/{id}")]
        public ActionResult<ReadAllStudentDTO> GetStudent([FromRoute] int id)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpGet("GetStudentProfile/{id}")]

        public ActionResult<ReadProfileStudentDTO> GetProfileStudent([FromRoute] int id)
        {
            ReadProfileStudentDTO studentProfile = _studentService.GetProfile(id);
            if (studentProfile == null)
            {
                return NotFound();
            }

            return Ok(studentProfile);
        }


        [HttpPut("UpdateStudent")]
        public ActionResult UpdateStudent([FromBody] UpdateStudentDTO student)
        {
            //var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            //if (!int.TryParse(userIdClaim, out int companyId))
            //return Unauthorized();

            var studentId = student.IdUser;

            _studentService.UpdateStudent(student, studentId);

            return Ok();

        }

    }
}
