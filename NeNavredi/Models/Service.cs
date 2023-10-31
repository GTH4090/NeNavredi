using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Code { get; set; } = null!;

    public TimeOnly Time { get; set; }

    public decimal AvargeDeviation { get; set; }

    public virtual ICollection<BookkeeperService> BookkeeperServices { get; set; } = new List<BookkeeperService>();

    public virtual ICollection<CompleeteService> CompleeteServices { get; set; } = new List<CompleeteService>();

    public virtual ICollection<EmployeeService> EmployeeServices { get; set; } = new List<EmployeeService>();

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
}
