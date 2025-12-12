using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class Kur
{
    public int KursId { get; set; }

    public int? LehrerId { get; set; }

    public int? FachId { get; set; }

    public int? KlasseId { get; set; }

    public string? Schuljahr { get; set; }

    public string? Bemerkung { get; set; }

    public virtual ICollection<Anwesenheit> Anwesenheits { get; set; } = new List<Anwesenheit>();

    public virtual Fach? Fach { get; set; }

    public virtual Klasse? Klasse { get; set; }

    public virtual Lehrer? Lehrer { get; set; }

    public virtual ICollection<Noten> Notens { get; set; } = new List<Noten>();

    public virtual ICollection<Stundenplan> Stundenplans { get; set; } = new List<Stundenplan>();
}
