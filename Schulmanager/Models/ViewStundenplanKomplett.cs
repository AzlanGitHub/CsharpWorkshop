using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class ViewStundenplanKomplett
{
    public int? StundenplanId { get; set; }

    public string? Klasse { get; set; }

    public string? Tag { get; set; }

    public int? Stunde { get; set; }

    public string? Zeit { get; set; }

    public string? Fach { get; set; }

    public string? Lehrer { get; set; }

    public string? RaumNr { get; set; }

    public string? Gebaeude { get; set; }
}
