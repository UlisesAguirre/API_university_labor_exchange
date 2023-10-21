namespace API_university_labor_exchange.Models.SkillDTOs
{
    public class UpdateSkillDto
    {
        public int IdSkill { get; set; }

        public string? SkillName { get; set; }

        public bool? State { get; set; } = true;
    }
}
