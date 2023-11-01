using System;
using System.Collections.Generic;

namespace NeNavredi.Models;

public partial class Client
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronomic { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public DateTime BirthDate { get; set; }

    public string PassportNumber { get; set; } = null!;

    public string PassportSerial { get; set; } = null!;

    public int? OrganisationId { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? CountryId { get; set; }

    public string? Guid { get; set; }

    public string? SocialSecNum { get; set; }

    public string? Ein { get; set; }

    public int? SocialSecTypeId { get; set; }

    public string? IpAddress { get; set; }

    public string? Ua { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Organisation? Organisation { get; set; }

    public virtual SoialSecType? SocialSecType { get; set; }
}
