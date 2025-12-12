using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class Stundenplan
{
    public int StundenplanId { get; set; }
    public int KursId { get; set; }
    public int RaumId { get; set; }
    public int SlotId { get; set; }
    public int? Wochentag { get; set; }
    public string? Status { get; set; }
    public string? DatumGueltig { get; set; }
    public virtual Kur Kurs { get; set; } = null!;
    public virtual Raum Raum { get; set; } = null!;
    public virtual Slot Slot { get; set; } = null!;
}
