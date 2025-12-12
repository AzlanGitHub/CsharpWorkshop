using System;
using System.Collections.Generic;

namespace Schulmanager.Models;

public partial class Slot
{
    public int SlotId { get; set; }
    public int? SlotNr { get; set; }
    public string VonZeit { get; set; } = null!;
    public string BisZeit { get; set; } = null!;
    public virtual ICollection<Stundenplan> Stundenplans { get; set; } = new List<Stundenplan>();
}
