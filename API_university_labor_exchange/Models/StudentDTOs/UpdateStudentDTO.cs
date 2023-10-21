
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.SkillDTOs;
using System.Text.Json.Serialization;

namespace API_university_labor_exchange.Models.Student
{
    public class UpdateStudentDTO
    {
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DocumentType? DocumentType { get; set; }

        public string? DocumentNumber { get; set; }

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime? BirthDate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CivilStatus? CivilStatus { get; set; }

        public string? Cuil { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Sex? Sex { get; set; }

        public string? Address { get; set; }

        public int? AddressNumber { get; set; }

        public int? Floor { get; set; }

        public string? Flat { get; set; }

        public string? Country { get; set; }

        public string? Province { get; set; }

        public string? City { get; set; }

        public string? GithubProfileUrl { get; set; }

        public string? LinkedInProfileUrl { get; set; }

        public string? TelephoneNumber { get; set; }

        public int? ApprovedSubjects { get; set; }

        public string? StudyProgram { get; set; }

        public int? CurrentCareerYear { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Turn? Turn { get; set; }

        public double? Average { get; set; }

        public double? AverageWithFails { get; set; }

        public string? SecondaryDegree { get; set; }

        public string? Observations { get; set; }

        public int IdUser { get; set; }
        public virtual List<StudentSkillsDto> StudentsSkills { get; set; } = new List<StudentSkillsDto>();

        public int? IdCareer { get; set; }

    }
}
