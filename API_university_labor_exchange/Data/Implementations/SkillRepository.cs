using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.SkillDTOs;

namespace API_university_labor_exchange.Data.Implementations
{
    public class SkillRepository : Repository, ISkillRepository
    {
        public SkillRepository(UniversityLaborExchangeContext context) : base(context) { }

        public ICollection<Skill> GetSkillsForForm()
        {
            return _context.Skills.Where(s => s.State == true).OrderBy(s => s.SkillName).ToList();
        }

        public Skill? GetSkill(int? skillId)
        {
            return _context.Skills.Find(skillId);
        }

        public void AddSkill(Skill newSkill)
        {
            _context.Add(newSkill);
        }

        public Skill UpdateSkill(CreateSkillDTO updateSkill)
        {

            var existingSkill = _context.Skills.FirstOrDefault(s => s.IdSkill == updateSkill.IdSkill);

            if (existingSkill != null)
            {
                existingSkill.SkillName = updateSkill.SkillName;
                _context.SaveChanges();
            }

            return existingSkill;
        }

        public void DeleteSkill(int? skillId)
        {
            var skill = _context.Skills.Find(skillId);

            if (skill != null)
            {
                skill.State = false;
            }
        }
    }
}
