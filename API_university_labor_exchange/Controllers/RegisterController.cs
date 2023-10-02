using API_university_labor_exchange.Models.Company;
using API_university_labor_exchange.Models.StudentDTOs;
using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_university_labor_exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost("RegisterStudent")]
        public ActionResult<bool> CreateStudent(CreateStudentDTO student)
        {
            bool newStudent = _registerService.CreateStudent(student);

            if (newStudent == true)
            {
                return Ok(new { message = "Ok" });
            }

            return BadRequest();
        }

        [HttpPost("RegisterCompany")]
        public ActionResult<bool> CreateCompany(CreateCompanyDTO company)
        {
            bool newCompany = _registerService.CreateCompany(company);

            if (newCompany == true)
            {
                return Ok(new { message = "Ok" });
            }

            return BadRequest();
        }
    }
}
