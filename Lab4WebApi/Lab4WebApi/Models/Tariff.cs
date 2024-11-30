using System;
using System.Collections.Generic;

namespace Lab4WebApi.Models;

public partial class Tariff
{
    public int Id { get; set; }

    public int ServiceId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Service Service { get; set; } = null!;
}
