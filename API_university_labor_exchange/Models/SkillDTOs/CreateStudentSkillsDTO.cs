namespace API_university_labor_exchange.Models.SkillDTOs
{
    public class CreateStudentSkillsDTO
    {
        public string Legajo { get; set; } = null!;

        public int IdSkill { get; set; }

        public string? SkillLevel { get; set; }
    }
}
