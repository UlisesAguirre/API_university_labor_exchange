namespace API_university_labor_exchange.Models.SkillDTOs
{
    public class StudentSkillsDto
    {
        public int? IdSkill { get; set; }
        public string? SkillLevel { get; set; }
        public string Legajo { get; set; } = null!;
    }
}
