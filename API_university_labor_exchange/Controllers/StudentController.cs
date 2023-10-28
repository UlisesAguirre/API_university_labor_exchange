using API_university_labor_exchange.Models;
using API_university_labor_exchange.Models.Student;
using API_university_labor_exchange.Models.StudentDTOs;
using API_university_labor_exchange.Services.Implementations;
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

        [HttpGet("GetStudentsToAdmin")]
        [Authorize(Roles = "admin")]
        public ActionResult<ICollection<ReadStudentsToAdmin>> GetStudentsForAdmin()
        {
            try
            {
                var students = _studentService.GetStudentsForAdmin();
                if (students == null)
                    return NotFound("No se encontraron estudiantes");
                return Ok(students);
            }
            catch (Exception)
            {
                return BadRequest("Error al acceder a los datos de los estudiantes");
            }

        }

        [HttpGet("GetStudent/{id}")]
        [Authorize(Roles = "student")]
        public ActionResult<ReadAllStudentDTO> GetStudent([FromRoute] int id)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (!int.TryParse(userIdClaim, out int userId))
                    return Unauthorized("Usted no esta autorizado");

                if (id != userId)
                    return Forbid("Acceso prohibido");


                var student = _studentService.GetStudent(userId);

                if (student == null)
                    return NotFound("Estudiante no encontrado");

                return Ok(student);
            }
            catch (Exception)
            {
                return BadRequest("Error al acceder a los datos del estudiante");
            }
        }

        [HttpGet("GetStudentProfile/{id}")]
        [Authorize(Roles = "student")]
        public ActionResult<ReadProfileStudentDTO> GetProfileStudent([FromRoute] int id)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (!int.TryParse(userIdClaim, out int userId))
                    return Unauthorized("Usted no esta autorizado");

                if (id != userId)
                    Forbid("Acceso prohibido");

                ReadProfileStudentDTO studentProfile = _studentService.GetProfile(id);
                if (studentProfile == null)
                    return NotFound("Estudiante no encontrado");

                return Ok(studentProfile);
            }
            catch (Exception)
            {
                return BadRequest("Error al acceder a los datos del estudiante");
            }


        }


        [HttpPut("UpdateStudent")]
        [Authorize(Roles = "student")]
        public ActionResult UpdateStudent([FromBody] UpdateStudentDTO student)
        {
            //try
            //{
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (!int.TryParse(userIdClaim, out int userId))
                    return Unauthorized("Usted no esta autorizado");

                if (student.IdUser != userId)
                    Forbid("Acceso prohibido");


                var skills = student.StudentsSkills;

                _studentService.UpdateStudent(student, userId);

                _studentService.UpdateSkills(skills, userId);

                return Ok(skills);
            //}
            //catch (Exception)
            //{
            //    return BadRequest("Error al actualizar los datos del estudiante");
            //}


        }

        [HttpPut("SetUserState")]
        [Authorize(Roles = "admin")]
        public ActionResult SetUserState(SetUserStateDTO user)
        {
            try
            {
                _studentService.SetUserState(user);
                return Ok("Estado actualizado con exito");
            }
            catch
            {
                return BadRequest("Error al actualizar el estado");
            }

        }

        [HttpPut("AddCurriculum")]
        [Authorize(Roles = "student")]
        public ActionResult AddCurriculum([FromForm] AddCurriculumDTO request)
        {
            try
            {

                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (!int.TryParse(userIdClaim, out int studentId))
                    return Unauthorized("Usted no esta autorizado");

                if (request.Id != studentId)
                    return Forbid("Acceso prohibido");

                IFormFile curriculum = request.Curriculum;

                if (curriculum.Length < 0)
                    return BadRequest("Debe agregar un archivo pdf valido");

                _studentService.AddCurriculum(curriculum, studentId);

                return Ok("Curriculum agregado con exito");
            }
            catch (Exception)
            {
                return BadRequest("Error al agregar el curriculum");
            }

        }

        [HttpPut("DeleteCurriculum")]
        [Authorize(Roles = "student")]
        public ActionResult DeleteCurriculum([FromBody] int id)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (!int.TryParse(userIdClaim, out int studentId))
                    return Unauthorized("Usted no esta autorizado");

                if (id != studentId)
                    return Forbid("Acceso prohibido");

                _studentService.DeleteCurriculum(studentId);
                    return Ok("curriculum eliminado con exito");
                
            }
            catch (Exception ex)
            {
                return BadRequest("Error al eliminar el curriculum" + ex);
            }


        }

        [HttpGet("GetCurriculum/{id}")]
        [Authorize(Roles = "student, company")]
        public ActionResult GetCurriculum([FromRoute] int id)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                if (!int.TryParse(userIdClaim, out int userId))
                    return Unauthorized("Usted no esta autorizado");

                if ((userRole == "student" && id != userId) || (userRole != "student" && userRole != "company"))
                    return Forbid("Acceso prohibido");

                var student = _studentService.GetCurriculum(id);

                if (student == null)
                    return NotFound("Estudiante no encontrado");

                if (student.Curriculum != null)
                    return File(student.Curriculum, "application/pdf", $"{student.Name}_{student.LastName}_CV.pdf");

                return NotFound("Curriculum no encontrado");
            }
            catch (Exception)
            {
                return BadRequest("Error al acceder a los datos del alumno");
            }

        }


    }
}
