﻿
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.Student;
using API_university_labor_exchange.Models.StudentDTOs;
using API_university_labor_exchange.Services.Implementations;
using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

            var skills = student.StudentsSkills;

            _studentService.UpdateStudent(student, studentId);

            _studentService.UpdateSkills(skills, studentId);

            return Ok(skills);

        }

        [HttpPut("AddCurriculum")]
        public ActionResult AddCurriculum([FromForm] AddCurriculumDTO request)
        {
            //var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            //if (!int.TryParse(userIdClaim, out int studentId))
            //    return Unauthorized();

            var studentId = request.Id;

            IFormFile curriculum = request.Curriculum;

            if (curriculum.Length < 0)
                return BadRequest("Debe agregar un archivo pdf valido");

            _studentService.AddCurriculum(curriculum, studentId);

            return Ok();
        }

        [HttpPut("DeleteCurriculum")]
        public ActionResult DeleteCurriculum([FromBody] int id)
        {
            if(_studentService.DeleteCurriculum(id))
               return Ok("curriculum eliminado con exito");
            return BadRequest("Error al eliminar el curriculum");
        }

        [HttpGet("GetCurriculum/{id}")]
        public ActionResult GetCurriculum([FromRoute] int id)
        {
            var student = _studentService.GetCurriculum(id);

            if (student == null)
                return NotFound();

            if(student.Curriculum != null)
                return File(student.Curriculum, "application/pdf", $"{student.Name}_{student.LastName}_CV.pdf");

            return NotFound("No tiene curriculum");
        }
    }
}
