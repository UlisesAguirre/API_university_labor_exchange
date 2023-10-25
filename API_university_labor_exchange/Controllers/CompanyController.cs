using API_university_labor_exchange.Models.Company;
using API_university_labor_exchange.Models.CompanyDTOs;
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
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IJobPositionService _jobPositionservice;

        public CompanyController(ICompanyService companyService, IJobPositionService jobPositionService)
        {
            _companyService = companyService;
            _jobPositionservice = jobPositionService;
        }


        [HttpGet("GetCompanyProfile/{id}")]
        [Authorize(Roles = "company")]
        public ActionResult<ReadProfileCompanyDTO> GetProfileCompany([FromRoute] int id)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (!int.TryParse(userIdClaim, out int companyId))
                    return Unauthorized("Usted no esta autorizado");

                if (id != companyId)
                    return Forbid("Acceso prohibido");


                ReadProfileCompanyDTO companyProfile = _companyService.GetProfile(id);

                if (companyProfile == null)
                    return NotFound("No se encontró a la compañía");
                return Ok(companyProfile);
            }
            catch (Exception)
            {
                return BadRequest("Error al acceder a los datos de la compañía");
            }

        }

        [HttpGet("GetCompaniesToAdmin")]
        [Authorize(Roles = "admin")]
        public ActionResult<ICollection<ReadCompaniesToAdmin>> GetCompaniesForAdmin()
        {
            try
            {
                var companies = _companyService.GetCompaniesForAdmin();
                return Ok(companies);
            }
            catch (Exception)
            {
                return BadRequest("Error al acceder a los datos de las compañías");
            }

        }

        [HttpGet("GetCompany/{id}")]
        [Authorize(Roles = "company")]
        public ActionResult<ReadAllCompanyDTO> GetCompany([FromRoute] int id)
        {
            try
            {

                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (!int.TryParse(userIdClaim, out int companyId))
                    return Unauthorized("Usted no esta autorizado");

                if (id != companyId)
                    return Forbid("Acceso prohibido");

                var company = new ReadAllCompanyDTO();
                company = _companyService.GetCompany(companyId);
                if (company == null)
                    return NotFound("No se encontro la compañía");
                return Ok(company);

            }
            catch (Exception)
            {
                return BadRequest("Error acceder a los datos de la compañía");
            }

        }

        [HttpGet("GetCompanyJobPositionsInfo")]
        [Authorize(Roles = "company")]
        public ActionResult<ICollection<ReadJobPositionCompanyDTO>> GetCompanyJobPositionsInfo()
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (!int.TryParse(userIdClaim, out int companyId))
                    return Unauthorized("Usted no esta autorizado");


                var company = _companyService.GetCompany(companyId);
                if (company == null)
                    return NotFound("No se encontraro la compañía");

                var cuit = company.Cuit;

                var jobPosition = _jobPositionservice.GetCompanyJobPositions(cuit);

                if (jobPosition != null)
                    return Ok(jobPosition);
                return NotFound("No se encontraron ofertas laborales");
            }
            catch (Exception)
            {
                return BadRequest("Error acceder a los datos de las ofertas laborales");
            }
        }

        [HttpPut("UpdateCompany")]
        [Authorize(Roles = "company")]
        public ActionResult UpdateCompany([FromBody] UpdateCompanyDTO company)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (!int.TryParse(userIdClaim, out int companyId))
                    return Unauthorized("Usted no esta autorizado");

                if (company.IdUser != companyId)
                    return Forbid("Acceso prohibido");


                _companyService.UpdateCompany(company, companyId);
                return Ok("Compañia actualizada con exito");

            }
            catch (Exception)
            {
                return BadRequest("Error al actualizar la compañía");
            }

        }


        [HttpPost("AddJobPosition")]
        [Authorize(Roles = "company")]
        public ActionResult AddJobPosition([FromBody] CreateJobPositionDTO jobPositionDTO)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (!int.TryParse(userIdClaim, out int companyId))
                    return Unauthorized("Usted no esta autorizado");

                var company = _companyService.GetCompany(companyId);
                if (company == null)
                    return NotFound("Compañía no encontrada");

                jobPositionDTO.IdCompany = company.Cuit;

                _jobPositionservice.AddJobPosition(jobPositionDTO);
                return Ok("Busqueda Laboral agregada con exito");

            }
            catch (Exception)
            {
                return BadRequest("Error al agregar la oferta laboral");
            }

        }

    }
}
