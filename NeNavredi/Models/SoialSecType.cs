using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class SoialSecType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
