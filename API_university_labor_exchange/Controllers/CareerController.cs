using API_university_labor_exchange.Models.CareerDTOs;
using API_university_labor_exchange.Services.Implementations;
using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_university_labor_exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CareerController : ControllerBase
    {
        private readonly ICareerService _careerService;

        public CareerController(ICareerService careerService)
        {
            _careerService = careerService;
        }


        [HttpGet("GetCareersForForms")]
        [Authorize(Roles = "admin, student, company")]
        public ActionResult<ICollection<ReadCareersForFormDTO>> GetCareersForForms()
        {
            try
            {
                var careers = _careerService.GetCareersForForm();
                if (careers == null)
                    return NotFound("No se econtraron carreras");
                return Ok(careers);
            }
            catch
            {
                return BadRequest("Error al acceder a los datos de las carreras");
            }

        }


        [HttpPost("CreateCareer")]
        [Authorize(Roles = "admin")]
        public ActionResult AddCareer(CreateCareerDTO career)
        {
            try
            {
                if (career.IdCareer == 0)
                {
                    _careerService.AddCareer(career);
                    return Ok("Carrera cargada con exito");
                }

                _careerService.UpdateCareer(career);
                return Ok("Carrera modificada con exito");
            }
            catch (Exception)
            {
                return BadRequest("Error al cargar los datos de la carrera");
            }

        }

        [HttpDelete("DeleteCareer/{careerId}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteCareer([FromRoute] int careerId)
        {
            try
            {
                _careerService.DeleteCareer(careerId);
                return Ok("Carrera borrada con exito");
            }
            catch (Exception)
            {
                return BadRequest("Error al borrar los datos de la carrera");
            }

        }

    }
}
