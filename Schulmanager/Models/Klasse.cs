using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class Klasse
{
    public int KlasseId { get; set; }

    public string Bezeichnung { get; set; } = null!;

    public string Kuerzel { get; set; } = null!;

    public int Jahrgangsstufe { get; set; }

    public string Schuljahr { get; set; } = null!;

    public int? KlassenlehrerId { get; set; }

    public virtual Lehrer? Klassenlehrer { get; set; }

    public virtual ICollection<Kur> Kurs { get; set; } = new List<Kur>();

    public virtual ICollection<LehrerFach> LehrerFaches { get; set; } = new List<LehrerFach>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
