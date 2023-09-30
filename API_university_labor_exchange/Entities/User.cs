using System;
using System.Collections.Generic;

namespace API_university_labor_exchange.Entities;

public partial class User
{
    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public int IdUser { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
