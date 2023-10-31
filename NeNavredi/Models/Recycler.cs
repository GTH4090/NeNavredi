using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class Recycler
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CompleeteService> CompleeteServices { get; set; } = new List<CompleeteService>();

    public virtual ICollection<RecyclerWork> RecyclerWorks { get; set; } = new List<RecyclerWork>();
}
