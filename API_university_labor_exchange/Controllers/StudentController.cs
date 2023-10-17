using API_university_labor_exchange.Models.Student;
using API_university_labor_exchange.Models.StudentDTOs;
using API_university_labor_exchange.Services.Interfaces;
using Azure.Core;
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

        [HttpPut("AddCurriculum")]
        [Authorize(Roles = "student")]
        public ActionResult AddCurriculum([FromForm] AddCurriculumDTO request)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdClaim, out int studentId))
                return Unauthorized();

            if (request.Id != studentId)
            {
                return Forbid();
            }

            IFormFile curriculum = request.Curriculum;

            if (curriculum.Length < 0)
                return BadRequest("Debe agregar un archivo pdf valido");

            _studentService.AddCurriculum(curriculum, studentId);

            return Ok();
        }

        [HttpPut("DeleteCurriculum")]
        [Authorize(Roles = "student")]
        public ActionResult DeleteCurriculum([FromBody] int id)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdClaim, out int studentId))
                return Unauthorized();

            if (id != studentId)
            {
                return Forbid();
            }

            if (_studentService.DeleteCurriculum(id))
               return Ok("curriculum eliminado con exito");
            return BadRequest("Error al eliminar el curriculum");
        }

        [HttpGet("GetCurriculum/{id}")]
        [Authorize(Roles = "student")]
        public ActionResult GetCurriculum([FromRoute] int id)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdClaim, out int studentId))
                return Unauthorized();

            if (id != studentId)
            {
                return Forbid();
            }

            var student = _studentService.GetCurriculum(id);

            if (student == null)
                return NotFound();

            if(student.Curriculum != null)
                return File(student.Curriculum, "application/pdf", $"{student.Name}_{student.LastName}_CV.pdf");

            return NotFound("No tiene curriculum");
        }
    }
}
