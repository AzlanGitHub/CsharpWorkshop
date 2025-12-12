using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class Lehrer
{
    public int LehrerId { get; set; }

    public string Vorname { get; set; } = null!;

    public string Nachname { get; set; } = null!;

    public DateOnly Geburtsdatum { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Klasse> Klasses { get; set; } = new List<Klasse>();

    public virtual ICollection<Kur> Kurs { get; set; } = new List<Kur>();

    public virtual ICollection<LehrerFach> LehrerFaches { get; set; } = new List<LehrerFach>();

    public virtual ICollection<StudentFach> StudentFaches { get; set; } = new List<StudentFach>();
}
