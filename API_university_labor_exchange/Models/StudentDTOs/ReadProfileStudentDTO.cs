using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Enums;
using API_university_labor_exchange.Models.SkillDTOs;
using System.Text.Json.Serialization;

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
        public int? IdCareer { get; set; }
        public string? CareerName { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public State State { get; set; }
        public virtual ICollection<StudentSkillsDto> StudentsSkills { get; set; } = new List<StudentSkillsDto>();

    }
}
