using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class EmployeeService
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ServiceId { get; set; }

    public virtual Service Service { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
