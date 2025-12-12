using System;
using System.Collections.Generic;

namespace Schulmanager.Models;
public partial class Student
{
    public int StudentId { get; set; }
    public string Vorname { get; set; } = null!;
    public string Nachname { get; set; } = null!;
    public DateOnly Geburtsdatum { get; set; }
    public string Strasse { get; set; } = null!;
    public string Stadt { get; set; } = null!;
    public int? KlasseId { get; set; }
    public virtual ICollection<Anwesenheit> Anwesenheits { get; set; } = new List<Anwesenheit>();
    public virtual Klasse? Klasse { get; set; }
    public virtual ICollection<Noten> Notens { get; set; } = new List<Noten>();
    public virtual ICollection<StudentFach> StudentFaches { get; set; } = new List<StudentFach>();
}
