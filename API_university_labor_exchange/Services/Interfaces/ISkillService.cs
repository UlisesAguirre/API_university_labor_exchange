using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.SkillDTOs;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface ISkillService
    {
        public ReadSkillDTO? GetSkill(int skillId);
        public void AddSkill(CreateSkillDTO createSkillDTO);

        public ICollection<ReadSkillDTO> GetSkillsForForm();

        CreateSkillDTO UpdateSkill(CreateSkillDTO updateSkill);

        void DeleteSkill(int skillId);
    }
}
