using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class Raum
{
    public int RaumId { get; set; }

    public string? RaumNr { get; set; }

    public int? Kapazitaet { get; set; }

    public string? Gebaeude { get; set; }

    public string? Ausstattung { get; set; }

    public string? ErstelltAm { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Stundenplan> Stundenplans { get; set; } = new List<Stundenplan>();
}
