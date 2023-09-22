using System;
using System.Collections.Generic;

namespace API_university_labor_exchange.Models;

public partial class StudentsJobPosition
{
    public string Legajo { get; set; } = null!;

    public int IdJobPosition { get; set; }

    public int IdStudentJobPosition { get; set; }

    public virtual JobPosition IdJobPositionNavigation { get; set; } = null!;

    public virtual Student LegajoNavigation { get; set; } = null!;
}
