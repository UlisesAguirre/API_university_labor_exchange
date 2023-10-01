using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_university_labor_exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
       private readonly IStudentService _studentService;
       public StudentController(IStudentService studentService) 
        {
            _studentService = studentService;
        }
    }
}
