using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class Bookkeeper
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronomic { get; set; }

    public DateTime? LastEnter { get; set; }

    public virtual ICollection<BookkeeperBill> BookkeeperBills { get; set; } = new List<BookkeeperBill>();

    public virtual ICollection<BookkeeperService> BookkeeperServices { get; set; } = new List<BookkeeperService>();
}
