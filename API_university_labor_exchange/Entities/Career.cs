using System;
using System.Collections.Generic;

namespace API_university_labor_exchange.Entities;

public partial class Career
{
    public int IdCareer { get; set; }

    public string? Name { get; set; }

    public string? Abbreviation { get; set; }

    public CareerType? CareerType { get; set; }

    public int TotalSubjets { get; set; }

    public bool? State { get; set; }

    public virtual ICollection<JobPositionsCareer> JobPositionsCareers { get; set; } = new List<JobPositionsCareer>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

