using API_university_labor_exchange.Data.Implementations;
using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Interfaces
{
    public interface ISkillRepository : IRepository
    {
        public IEnumerable<Skill> GetAllSkills();
        public Skill? GetSkill(int? skillId);
        public void AddSkill(Skill newSkill);

        public ICollection<Skill> GetSkillsForForm();
        void DeleteSkill(int? skillId);
    }
}
