using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class LehrerFach
{
    public int LehFaId { get; set; }

    public int LehrerId { get; set; }

    public int FachId { get; set; }

    public int KlasseId { get; set; }

    public string? Bemerkung { get; set; }

    public string? Schuljahr { get; set; }

    public string? Von { get; set; }

    public string? Bis { get; set; }

    public virtual Fach Fach { get; set; } = null!;

    public virtual Klasse Klasse { get; set; } = null!;

    public virtual Lehrer Lehrer { get; set; } = null!;
}
