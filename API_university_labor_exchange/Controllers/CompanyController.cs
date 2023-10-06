using API_university_labor_exchange.Models.Company;
using API_university_labor_exchange.Models.CompanyDTOs;
using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_university_labor_exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetAllCompanies")]
        public ActionResult<ICollection<ReadAllCompanyDTO>> GetAllCompanies()
        {
            var companies = _companyService.GetAllCompanies(); 
            return Ok(companies);
        }

        [HttpGet("GetCompany/{id}")]
        public ActionResult<ReadAllCompanyDTO> GetCompany([FromRoute] int id)
        {
            var company = _companyService.GetCompany(id);
            if (company == null)
                return NotFound();
            return Ok(company);
        }

        [HttpPut("UpdateCompany")]
        public ActionResult UpdateCompany([FromBody] UpdateCompanyDTO company)
        {
            //var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            //if (!int.TryParse(userIdClaim, out int companyId))
            //return Unauthorized();

            var companyId = company.IdUser;
            
            _companyService.UpdateCompany(company, companyId);
            return Ok("Compañia actualizada con exito");
            
        }

        [HttpGet("GetCompanyProfile/{id}")]

        public ActionResult<ReadProfileCompanyDTO> GetProfileCompany([FromRoute] int id)
        {
            ReadProfileCompanyDTO companyProfile = _companyService.GetProfile(id);
            if (companyProfile == null)
            {
                return NotFound();
            }

            return Ok(companyProfile);
        }
    }
}
