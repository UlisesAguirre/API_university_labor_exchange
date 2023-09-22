using System;
using System.Collections.Generic;

namespace API_university_labor_exchange.Models;

public partial class Skill
{
    public int IdSkill { get; set; }

    public string? SkillName { get; set; }

    public virtual ICollection<JobPostionsSkill> JobPostionsSkills { get; set; } = new List<JobPostionsSkill>();

    public virtual ICollection<StudentsSkill> StudentsSkills { get; set; } = new List<StudentsSkill>();
}
