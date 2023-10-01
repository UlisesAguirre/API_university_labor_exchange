using API_university_labor_exchange.Models.CareerDTOs;
using API_university_labor_exchange.Models.SkillDTOs;
using API_university_labor_exchange.Services.Implementations;
using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_university_labor_exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
       
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet("GetAllSkills")]
        public ActionResult<ICollection<ReadSkillDTO>> GetAllSkills() 
        {
            var skills = _skillService.GetAllSkills();
            return Ok(skills);
        }


        [HttpGet("GetSkill")]
        public ActionResult<ReadSkillDTO> GetSkill(int skillId)
        {
            var skill = _skillService.GetSkillBy(skillId);
            if(skill == null)
                return NotFound();
            return Ok(skill);
        }

        [HttpPost("CreateSkill")]
        public ActionResult AddSkill(CreateSkillDTO skill)
        {
            _skillService.AddSkill(skill);
            return Ok("Habilidad cargada con exito");
        }



    }
}
