using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class Noten
{
    public int NotenId { get; set; }

    public int? StudentId { get; set; }

    public int? KursId { get; set; }

    public decimal? Note { get; set; }

    public DateOnly? Datum { get; set; }

    public string? Art { get; set; }

    public virtual Kur? Kurs { get; set; }

    public virtual Student? Student { get; set; }
}
