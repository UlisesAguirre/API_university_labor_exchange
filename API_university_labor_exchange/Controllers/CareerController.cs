using API_university_labor_exchange.Models.CareerDTOs;
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

        [HttpGet("{careerId}", Name = "GetCareer")]
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
            var newCareer = _careerService.AddCareer(career);

            if(newCareer == null) 
                return BadRequest();
            return CreatedAtRoute("GetCareer", new {careerId = newCareer.IdCarrer}, newCareer);
        }

    }
}
