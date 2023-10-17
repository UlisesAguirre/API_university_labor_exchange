using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Implementations
{
    public class SkillRepository : Repository, ISkillRepository
    {
        public SkillRepository(UniversityLaborExchangeContext context) : base(context) { }

        public IEnumerable<Skill> GetAllSkills()
        {
            return _context.Skills.OrderBy(s => s.SkillName).ToList();

        }
        public Skill? GetSkill(int? skillId)
        {
            return _context.Skills.Find(skillId);
        }
        public void AddSkill(Skill newSkill)
        {
            _context.Add(newSkill);
        }

        public void DeleteSkill(int? skillId)
        {
            var skill = _context.Skills.Find(skillId);

            if (skill != null)
            {
                _context.Skills.Remove(skill);
            }
        }
    }
}
