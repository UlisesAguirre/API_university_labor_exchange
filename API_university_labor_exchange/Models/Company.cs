using System;
using System.Collections.Generic;

namespace API_university_labor_exchange.Models;

public partial class Company
{
    public string? CompanyName { get; set; }

    public string Cuit { get; set; } = null!;

    public string SocialReason { get; set; } = null!;

    public string? TelephoneNumber { get; set; }

    public string? Sector { get; set; }

    public string? LegalAddress { get; set; }

    public string? PostalCode { get; set; }

    public string? Web { get; set; }

    public string? Location { get; set; }

    public string? RecruiterName { get; set; }

    public string? RecruiterLastName { get; set; }

    public string? RecruiterPosition { get; set; }

    public string? RecruiterPhoneNumber { get; set; }

    public string? RecruiterEmail { get; set; }

    public string? RecruiterRelWithCompany { get; set; }

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<JobPosition> JobPositions { get; set; } = new List<JobPosition>();
}
