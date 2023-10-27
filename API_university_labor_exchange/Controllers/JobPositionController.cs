
using API_university_labor_exchange.Models.JobPositionDTOs;
using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_university_labor_exchange.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class JobPositionController : ControllerBase
    {
        private IJobPositionService _jobPositionService;
        private IStudentService _studentService;

        public JobPositionController(IJobPositionService jobPositionService, IStudentService studentService)
        {
            _jobPositionService = jobPositionService;
            _studentService = studentService;
        }

        [HttpGet("GetAllInterships")]
        [Authorize(Roles = "admin")]
        public ActionResult<ICollection<ReadJobPositionDto>> GetAllInterships()
        {
            try
            {
                ICollection<ReadJobPositionDto> jobPosition = _jobPositionService.GetAllJobPosition();
                if (jobPosition == null)
                    return NotFound("No se encontraron pasantías");
                return Ok(_jobPositionService.GetAllInterships(jobPosition));

            }
            catch (Exception)
            {
                return BadRequest("Error al acceder a los datos de las pasantías");
            }

        }

        [HttpGet("GetAllJobs")]
        [Authorize(Roles = "admin")]
        public ActionResult<ICollection<ReadJobPositionDto>> GetAllJobs()
        {
            try
            {
                ICollection<ReadJobPositionDto> jobPosition = _jobPositionService.GetAllJobPosition();
                if (jobPosition == null)
                    return NotFound("No se encontraron pasantías");

                return Ok(_jobPositionService.GetAllJobs(jobPosition));
            }
            catch (Exception)
            {
                return BadRequest("Error al acceder a los datos de las pasantías");
            }

        }

        [HttpGet("GetJobPositions")]
        [Authorize(Roles = "student")]
        public ActionResult<ICollection<ReadJobPositionCompanyDTO>> GetJobPositions()
        {
            try
            {
                var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (!int.TryParse(userIdClaim, out int studentId))
                    return Unauthorized("No autorizado");


                var student = _studentService.GetStudent(studentId);
                if (student == null)
                    return NotFound("Estudiante no encontrado");

                var jobPosition = _jobPositionService.GetJobPosition(student.Legajo);

                if (jobPosition != null)
                    return Ok(jobPosition);
                return NotFound("No se encontraron ofertas laborales");
            }
            catch (Exception)
            {
                return BadRequest("Error al acceder a los datos de las ofertas laborales");
            }


        }

        [HttpPut("SetJobPositionState")]
        [Authorize(Roles = "admin")]
        public ActionResult SetJobPositionState(SetJobPositionStateDTO jobPosition)
        {
            try
            {
                _jobPositionService.SetJobPositionState(jobPosition);
                return Ok("Estado actualizado con exito");

            }
            catch (Exception)
            {
                return BadRequest("Error al actualizar el estado");
            }

        }

        [HttpPost("AddStudentJobPosition")]
        [Authorize(Roles = "student")]
        public ActionResult AddStudentJobPosition([FromBody] int idJobPosition)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (!int.TryParse(userIdClaim, out int studentId))
                    return Unauthorized("No autorizado");

                var student = _studentService.GetStudent(studentId);

                if (student == null)
                    return NotFound("No se encontro al estudiante");
                var legajo = student.Legajo;

                _jobPositionService.AddStudentJobPosition(legajo, idJobPosition);

                return Ok("Postulación agregada con exito");
            }
            catch (Exception)
            {
                return BadRequest("Error al guardar la postulación");
            }


        }
    }
}
