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
            var skill = _skillService.GetSkill(skillId);
            if(skill == null)
                return NotFound();
            return Ok(skill);
        }

        [HttpPost("CreateSkill")]
        public ActionResult AddSkill(CreateSkillDTO skill)
        {
            if(skill.IdSkill == 0)
            {
                _skillService.AddSkill(skill);
                return Ok("Habilidad cargada con exito");
            }

            return Ok("Habilidad modificada con exito");
        }

        [HttpDelete("DeleteSkill/{skillId}")]
        public ActionResult DeleteSkill([FromRoute] int skillId)
        {
            _skillService.DeleteSkill(skillId);
            return Ok("Habilidad borrada correctamente");

        }



    }
}
