using System.Text.Json.Serialization;

namespace API_university_labor_exchange.Models.JobPositionDTOs
{
    public class CreateJobPositionDTO
    {
        public string? JobTitle { get; set; }

        public string? JobDescription { get; set; }

        public string? BenefitsOfferedDetail { get; set; }

        public string? Location { get; set; }

        public int? PositionToCover { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public JobType? JobType { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? StartDate { get; set; }

        public int? NumberOfPositionsToCover { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WorkDay? WorkDay { get; set; }

        public int? InternshipDuration { get; set; }

        public DateTime? TentativeStartDate { get; set; }

        public string? IdCompany { get; set; }
        public List<JobPositionCareerDTO> jobPositionCareer { get; set; } = new List<JobPositionCareerDTO>();

        public List<JobPositionSkillDTO> jobPositionSkill { get; set; } = new List<JobPositionSkillDTO>();

    }
}
