using System;
using System.Collections.Generic;

namespace Lab4WebApi.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Tariff> Tariffs { get; set; } = new List<Tariff>();
}
