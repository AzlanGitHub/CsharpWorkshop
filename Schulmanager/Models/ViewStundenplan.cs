using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class ViewStundenplan
{
    public int? Wochentag { get; set; }

    public string? VonZeit { get; set; }

    public string? Fach { get; set; }

    public string? Lehrer { get; set; }

    public string? RaumNr { get; set; }
}
