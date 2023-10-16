using API_university_labor_exchange.Models.Student;
using API_university_labor_exchange.Models.StudentDTOs;
using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_university_labor_exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetAllStudents")]
        [Authorize(Roles = "admin")]
        public ActionResult<ICollection<ReadAllStudentDTO>> GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("GetStudent/{id}")]
        [Authorize(Roles = "student,admin")]
        public ActionResult<ReadAllStudentDTO> GetStudent([FromRoute] int id)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            var student = new ReadAllStudentDTO();

            if(userRole == "admin")
            {
                student = _studentService.GetStudent(id);
            } else
            {
                student = _studentService.GetStudent(Int32.Parse(userIdClaim));
            }

            
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpGet("GetStudentProfile/{id}")]
        [Authorize(Roles = "student")]

        public ActionResult<ReadProfileStudentDTO> GetProfileStudent([FromRoute] int id)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (id != Int32.Parse(userIdClaim))
            {
                Forbid();
            }

            ReadProfileStudentDTO studentProfile = _studentService.GetProfile(id);
            if (studentProfile == null)
            {
                return NotFound();
            }

            return Ok(studentProfile);
        }


        [HttpPut("UpdateStudent")]
        [Authorize(Roles = "student")]
        public ActionResult UpdateStudent([FromBody] UpdateStudentDTO student)
        {

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (student.IdUser != Int32.Parse(userIdClaim))
            {
                return Forbid();
            }

            var studentId = student.IdUser;

            var skills = student.StudentsSkills;

            _studentService.UpdateStudent(student, studentId);

            _studentService.UpdateSkills(skills, studentId);

            return Ok(skills);

        }

    }
}
