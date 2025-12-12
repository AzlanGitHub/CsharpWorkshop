using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class Fach
{
    public int FachId { get; set; }

    public string? Titel { get; set; }

    public string? Beschreibung { get; set; }

    public int? Credits { get; set; }

    public virtual ICollection<Kur> Kurs { get; set; } = new List<Kur>();

    public virtual ICollection<LehrerFach> LehrerFaches { get; set; } = new List<LehrerFach>();

    public virtual ICollection<StudentFach> StudentFaches { get; set; } = new List<StudentFach>();
}
