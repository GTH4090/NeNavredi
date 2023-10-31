using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class BookkeeperService
{
    public int Id { get; set; }

    public int BookkeeperId { get; set; }

    public int ServiceId { get; set; }

    public virtual Bookkeeper Bookkeeper { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
