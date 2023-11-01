using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class Address
{
    public int Id { get; set; }

    public int HouseNumber { get; set; }

    public int? StreetId { get; set; }

    public virtual ICollection<Organisation> Organisations { get; set; } = new List<Organisation>();

    public virtual Street? Street { get; set; }
}
