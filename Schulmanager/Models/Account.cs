using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class Account
{
    public int AccountId { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public string? Rolle { get; set; }
    public int? FremdId { get; set; }
}
