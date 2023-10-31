using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class RecyclerWork
{
    public int Id { get; set; }

    public int RecylerId { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public virtual Recycler Recyler { get; set; } = null!;
}
