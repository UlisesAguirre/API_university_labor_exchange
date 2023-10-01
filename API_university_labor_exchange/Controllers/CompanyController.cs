﻿using API_university_labor_exchange.Models.Company;
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

        [HttpGet("GetCompany")]
        public ActionResult<ReadAllCompanyDTO> GetCompany(int id)
        {
            var company = _companyService.GetCompany(id);
            if (company == null)
                return NotFound();
            return Ok(company);
        }

        [HttpPut("UpdateCompany")]
        public ActionResult UpdateCompany([FromBody] UpdateCompanyDTO company)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
           
            if (!int.TryParse(userIdClaim, out int companyId))
                return Unauthorized();
            
            _companyService.UpdateCompany(company, companyId);
            return Ok("Compañia actualizada con exito");
            
        }
    }
}
