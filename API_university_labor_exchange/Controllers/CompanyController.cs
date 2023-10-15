﻿using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.Company;
using API_university_labor_exchange.Models.CompanyDTOs;
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

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetAllCompanies")]
        [Authorize(Roles = "admin")]
        public ActionResult<ICollection<ReadAllCompanyDTO>> GetAllCompanies()
        {
            var companies = _companyService.GetAllCompanies(); 
            return Ok(companies);
        }


        [HttpGet("GetCompany/{id}")]
        [Authorize(Roles = "company,admin")]
        public ActionResult<ReadAllCompanyDTO> GetCompany([FromRoute] int id)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            var company = new ReadAllCompanyDTO();

            if (userRole == "admin")
            {
                company = _companyService.GetCompany(id);
            } else
            {
                company = _companyService.GetCompany(Int32.Parse(userIdClaim));
            }

            if (company == null)
                return NotFound();
            return Ok(company);
        }

        [HttpPut("UpdateCompany")]
        [Authorize(Roles = "company")]
        public ActionResult UpdateCompany([FromBody] UpdateCompanyDTO company)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if(company.IdUser != Int32.Parse(userIdClaim))
            {
                return Forbid();
            }

            var companyId = company.IdUser;
            
            _companyService.UpdateCompany(company, companyId);
            return Ok("Compañia actualizada con exito");
            
        }

        [HttpGet("GetCompanyProfile/{id}")]
        [Authorize(Roles = "company")]

        public ActionResult<ReadProfileCompanyDTO> GetProfileCompany([FromRoute] int id)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (id != Int32.Parse(userIdClaim))
            {
                return Forbid();
            }

            ReadProfileCompanyDTO companyProfile = _companyService.GetProfile(id);
            if (companyProfile == null)
            {
                return NotFound();
            }

            return Ok(companyProfile);
        }
    }
}
