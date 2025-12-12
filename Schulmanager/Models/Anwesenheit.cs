using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class Anwesenheit
{
    public int AnwesenheitId { get; set; }
    public int? StudentId { get; set; }
    public int? KursId { get; set; }
    public string? Datum { get; set; }
    public string? Status { get; set; }
    public string? Beemerkung { get; set; }
    public virtual Kur? Kurs { get; set; }
    public virtual Student? Student { get; set; }
}
