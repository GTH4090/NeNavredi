using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class EnterHistory
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Login { get; set; }

    public DateTime Date { get; set; }

    public string IpAddress { get; set; } = null!;

    public bool Succes { get; set; }

    public virtual User? User { get; set; }
}
