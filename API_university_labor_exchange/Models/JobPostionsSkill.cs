using System;
using System.Collections.Generic;

namespace API_university_labor_exchange.Models;

public partial class JobPostionsSkill
{
    public int IdJobPositionsSkills { get; set; }

    public int IdJobPosition { get; set; }

    public int IdSkill { get; set; }

    public string? SkillLevel { get; set; }

    public virtual JobPosition IdJobPositionNavigation { get; set; } = null!;

    public virtual Skill IdSkillNavigation { get; set; } = null!;
}
