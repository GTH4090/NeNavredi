using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class Admin
{
    public int Id { get; set; }

    public virtual User IdNavigation { get; set; } = null!;
}
