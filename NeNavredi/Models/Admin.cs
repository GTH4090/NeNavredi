using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
