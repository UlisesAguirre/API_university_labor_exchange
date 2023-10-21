using API_university_labor_exchange.Models.CareerDTOs;
using API_university_labor_exchange.Services.Implementations;
using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_university_labor_exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CareerController : ControllerBase
    {
        private readonly ICareerService _careerService;

        public CareerController(ICareerService careerService)
        {
            _careerService = careerService;
        }

        [HttpGet("GetAllCareers")]
        public ActionResult<ICollection<ReadCareerDTO>> GetAllCareers()
        {
            var careers = _careerService.GetAllCareers();
            return Ok(careers);
        }

        [HttpGet("GetCareersForForms")]
        public ActionResult<ICollection<ReadCareersForFormDTO>> GetCareersForForms()
        {
            var careers = _careerService.GetCareersForForm();
            return Ok(careers);
        }


        [HttpGet("GetCareer")]
        public ActionResult<ReadCareerDTO> GetCareer(int careerId) 
        {
            var career = _careerService.GetCareerById(careerId);
            if(career == null)
                return NotFound();
            return Ok(career);
            
        }

        [HttpPost ("CreateCareer")] 
        public ActionResult AddCareer (CreateCareerDTO career)
        {
            if(career.IdCareer == 0)
            {
                _careerService.AddCareer(career);
                return Ok("Carrera cargada con exito");
            }

            _careerService.UpdateCareer(career);
            return Ok("Carrera modificada con exito");
        }

        [HttpDelete("DeleteCareer/{careerId}")]
        public ActionResult DeleteCareer([FromRoute] int careerId)
        {
            _careerService.DeleteCareer(careerId);
            return Ok("Carrera borrada correctamente");

        }

    }
}
