using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class Employee
{
    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronomic { get; set; }

    public int Id { get; set; }

    public virtual User IdNavigation { get; set; } = null!;
}
