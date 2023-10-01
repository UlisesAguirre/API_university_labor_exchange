﻿using API_university_labor_exchange.Models.StudentDTOs;
using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_university_labor_exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpGet("RegisterStudent")]
        public ActionResult<bool> CreateStudent(CreateStudentDTO student)
        {
            bool newStudent = _registerService.CreateStudent(student);

            if (newStudent == true)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
