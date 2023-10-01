using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.SkillDTOs;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface ISkillService
    {
        public IEnumerable<ReadSkillDTO> GetAllSkills();
        public ReadSkillDTO? GetSkillBy(int skillId);
        public void AddSkill(CreateSkillDTO createSkillDTO);
    }
}
