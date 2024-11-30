using System;
using System.Collections.Generic;

namespace lab3.DBFirstModels;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateTime RegistrationDate { get; set; }
}
