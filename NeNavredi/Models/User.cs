using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Admin? Admin { get; set; }

    public virtual Bookkeeper? Bookkeeper { get; set; }

    public virtual ICollection<BookkeeperBill> BookkeeperBills { get; set; } = new List<BookkeeperBill>();

    public virtual ICollection<CompleeteService> CompleeteServices { get; set; } = new List<CompleeteService>();

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<EmployeeService> EmployeeServices { get; set; } = new List<EmployeeService>();

    public virtual ICollection<EnterHistory> EnterHistories { get; set; } = new List<EnterHistory>();

    public virtual ExplorerEmployee? ExplorerEmployee { get; set; }
}
