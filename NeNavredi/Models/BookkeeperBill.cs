using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class BookkeeperBill
{
    public int Id { get; set; }

    public int BookkeeperId { get; set; }

    public int OrganisationId { get; set; }

    public virtual Bookkeeper Bookkeeper { get; set; } = null!;

    public virtual Organisation Organisation { get; set; } = null!;
}
