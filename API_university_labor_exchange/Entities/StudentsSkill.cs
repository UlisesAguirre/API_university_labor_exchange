using System;
using System.Collections.Generic;

namespace API_university_labor_exchange.Entities;

public partial class StudentsSkill
{
    public int IdStudentsSkills { get; set; }

    public string Legajo { get; set; } = null!;

    public int IdSkill { get; set; }

    public SkillLevel? SkillLevel { get; set; }

    public virtual Skill IdSkillNavigation { get; set; } = null!;

    public virtual Student LegajoNavigation { get; set; } = null!;
}
