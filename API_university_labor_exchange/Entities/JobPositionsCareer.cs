using System;
using System.Collections.Generic;

namespace API_university_labor_exchange.Entities;

public partial class JobPositionsCareer
{
    public int IdJobPositionsCareers { get; set; }

    public int IdJobPosition { get; set; }

    public int IdCareer { get; set; }

    public virtual Career IdCareerNavigation { get; set; } = null!;

    public virtual JobPosition IdJobPositionNavigation { get; set; } = null!;
}
