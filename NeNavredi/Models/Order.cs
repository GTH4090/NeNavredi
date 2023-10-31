using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int Statusid { get; set; }

    public int? Time { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
}
