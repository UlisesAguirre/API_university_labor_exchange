using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.CareerDTOs;
using API_university_labor_exchange.Models.SkillDTOs;
using API_university_labor_exchange.Services.Implementations;
using API_university_labor_exchange.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_university_labor_exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SkillController : ControllerBase
    {

        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }


        [HttpGet("GetSkillsForForm")]
        [Authorize(Roles = "admin, student, company")]
        public ActionResult<ICollection<ReadSkillDTO>> GetSkillsForForm()
        {
            try
            {
                var skills = _skillService.GetSkillsForForm();
                if (skills == null)
                    return NotFound("Habilidades no encontradas");
                return Ok(skills);
            }
            catch (Exception)
            {
                return BadRequest("Error al acceder a las habilidades");
            }
        }


        //[HttpGet("GetSkill")]
        //public ActionResult<ReadSkillDTO> GetSkill(int skillId)
        //{
        //    try
        //    {
        //        var skill = _skillService.GetSkill(skillId);
        //        if (skill == null)
        //            return NotFound("Habilidades no encontradas");
        //        return Ok(skill);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Error al acceder a los datos de las habilidades");
        //    }
        //}

        [HttpPost("CreateSkill")]
        [Authorize(Roles = "admin")]
        public ActionResult AddSkill(CreateSkillDTO skill)
        {
            try
            {
                if (skill.IdSkill == 0)
                {
                    _skillService.AddSkill(skill);
                    return Ok("Habilidad cargada con exito");
                }

                CreateSkillDTO modifiedSkill = _skillService.UpdateSkill(skill);

                if (modifiedSkill == null)
                    return NotFound("Habilidad no encontrada");
                return Ok("Habilidad actualizada con exito");


            }
            catch (Exception)
            {
                return BadRequest("Error al cargar las habilidades");
            }
        }

        [HttpDelete("DeleteSkill/{skillId}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteSkill([FromRoute] int skillId)
        {
            try
            {
                _skillService.DeleteSkill(skillId);
                return Ok("Habilidad borrada correctamente");
            }
            catch (Exception)
            {
                return BadRequest("Error al borrar la habilidad");
            }


        }

    }
}
