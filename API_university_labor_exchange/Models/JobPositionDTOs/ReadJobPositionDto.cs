using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.JobPositionDTOs.SkillsCareerListDto;

namespace API_university_labor_exchange.Models.JobPositionDTOs
{
    public class ReadJobPositionDto
    {
        public int IdJobPosition { get; set; }

        public string? JobTitle { get; set; }

        public string? JobDescription { get; set; }

        public string? BenefitsOfferedDetail { get; set; }

        public string? Location { get; set; }

        public int? PositionToCover { get; set; }

        public JobType? JobType { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? NumberOfPositionsToCover { get; set; }

        public WorkDay? WorkDay { get; set; }

        public int? InternshipDuration { get; set; }

        public DateTime? TentativeStartDate { get; set; }

        public string? FrameworkAgreement { get; set; }

        public string IdCompany { get; set; } = null!;
        public string SocialReasonCompany { get; set; }
        public virtual List<CareersListDTO> JobPositionsCareers { get; set; } = new List<CareersListDTO>();

        public virtual List<SkillsListDTO> JobPostionsSkills { get; set; } = new List<SkillsListDTO>();

    }
}
