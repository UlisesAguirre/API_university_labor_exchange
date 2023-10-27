using API_university_labor_exchange.Data.Implementations;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.SkillDTOs;

namespace API_university_labor_exchange.Data.Interfaces
{
    public interface ISkillRepository : IRepository
    {
        public Skill? GetSkill(int? skillId);
        public void AddSkill(Skill newSkill);

        public ICollection<Skill> GetSkillsForForm();
        Skill UpdateSkill(CreateSkillDTO updateSkill);
        void DeleteSkill(int? skillId);
    }
}
