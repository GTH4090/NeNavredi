using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class BookkeeperBill
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int OrganisationId { get; set; }

    public virtual Organisation Organisation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
