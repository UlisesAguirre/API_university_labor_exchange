using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Models.StudentDTOs
{
    public class ReadProfileStudentDTO
    {
        public string Email { get; set; }
        public string Username { get; set; }

        public string Name { get; set; }
        
        public string LastName { get; set; }
        
        public DateTime? BirthDate { get; set; }
        
        public string? Country { get; set; }

        public string? Province { get; set; }

        public string? City { get; set; }

        public byte[]? Curriculum { get; set; }

        public string? GithubProfileUrl { get; set; }

        public string? LinkedInProfileUrl { get; set; }

        public string? TelephoneNumber { get; set; }

        public int? ApprovedSubjects { get; set; }

        public int? CurrentCareerYear { get; set; }

        public double? Average { get; set; }

        public int? IdCarrer { get; set; }
        public virtual ICollection<StudentsSkill> StudentsSkills { get; set; } = new List<StudentsSkill>();

    }
}
