using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class Organisation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Tin { get; set; } = null!;

    public string Bill { get; set; } = null!;

    public string Bik { get; set; } = null!;

    public virtual ICollection<BookkeeperBill> BookkeeperBills { get; set; } = new List<BookkeeperBill>();

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
