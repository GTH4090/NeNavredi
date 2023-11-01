using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class OrderService
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ServiceId { get; set; }

    public int StatusId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
