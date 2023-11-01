using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class Status
{
    public string Name { get; set; } = null!;

    public int Id { get; set; }

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
