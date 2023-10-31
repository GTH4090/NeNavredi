using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronomic { get; set; }

    public DateTime? LastEnter { get; set; }

    public bool IsExplorer { get; set; }

    public virtual ICollection<CompleeteService> CompleeteServices { get; set; } = new List<CompleeteService>();

    public virtual ICollection<EmployeeService> EmployeeServices { get; set; } = new List<EmployeeService>();
}
