using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class StudentFach
{
    public int StudentFachId { get; set; }
    public int StudentId { get; set; }
    public int FachId { get; set; }
    public int LehrerId { get; set; }
    public string? Semester { get; set; }
    public double? Note { get; set; }
    public virtual Fach Fach { get; set; } = null!;
    public virtual Lehrer Lehrer { get; set; } = null!;
    public virtual Student Student { get; set; } = null!;
}
