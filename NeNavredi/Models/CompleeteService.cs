﻿using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class CompleeteService
{
    public int Id { get; set; }

    public int ServiceId { get; set; }

    public DateTime Date { get; set; }

    public int EmployeeId { get; set; }

    public int RecyclerId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Recycler Recycler { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
