using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.JobPositionDTOs;
using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_university_labor_exchange.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class JobPositionController :ControllerBase
    {
        private IJobPositionService _jobPositionService;

        public JobPositionController(IJobPositionService jobPositionService)
        {
            _jobPositionService = jobPositionService;
        }

        [HttpGet("GetAllInterships")]
        public ActionResult<ICollection<ReadJobPositionDto>> GetAllInterships()
        {
            ICollection<ReadJobPositionDto> jobPosition = _jobPositionService.GetAllJobPosition();

            return Ok(_jobPositionService.GetAllInterships(jobPosition));
        }

        [HttpGet("GetAllJobs")]
        public ActionResult<ICollection<ReadJobPositionDto>> GetAllJobs()
        {
            ICollection<ReadJobPositionDto> jobPosition = _jobPositionService.GetAllJobPosition();

            return Ok(_jobPositionService.GetAllJobs(jobPosition));
        }
    }
}
