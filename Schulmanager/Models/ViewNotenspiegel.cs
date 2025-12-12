using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class ViewNotenspiegel
{
    public int? StudentId { get; set; }
    public string? Vorname { get; set; }
    public string? Nachname { get; set; }
    public string? Klasse { get; set; }
    public string? Fach { get; set; }
    public decimal? Note { get; set; }
    public string? Leistungsnachweis { get; set; }
    public DateOnly? Datum { get; set; }
    public string? Fachlehrer { get; set; }
}
