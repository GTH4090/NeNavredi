﻿using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
