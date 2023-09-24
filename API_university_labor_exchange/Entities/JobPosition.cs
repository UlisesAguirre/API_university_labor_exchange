using System;
using System.Collections.Generic;

namespace API_university_labor_exchange.Entities;

public partial class JobPosition
{
    public int IdJobPosition { get; set; }

    public string? JobTitle { get; set; }

    public string? JobDescription { get; set; }

    public string? BenefitsOfferedDetail { get; set; }

    public string? Location { get; set; }

    public int? PositionToCover { get; set; }

    public string? JobType { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? StartDate { get; set; }

    public int? NumberOfPositionsToCover { get; set; }

    public string? WorkDay { get; set; }

    public int? InternshipDuration { get; set; }

    public DateTime? TentativeStartDate { get; set; }

    public string? FrameworkAgreement { get; set; }

    public string IdCompany { get; set; } = null!;

    public virtual Company IdCompanyNavigation { get; set; } = null!;

    public virtual ICollection<JobPositionsCareer> JobPositionsCareers { get; set; } = new List<JobPositionsCareer>();

    public virtual ICollection<JobPostionsSkill> JobPostionsSkills { get; set; } = new List<JobPostionsSkill>();

    public virtual ICollection<StudentsJobPosition> StudentsJobPositions { get; set; } = new List<StudentsJobPosition>();
}
