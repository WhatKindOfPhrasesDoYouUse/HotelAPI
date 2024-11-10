using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class RoomComfort
{
    public int RoomId { get; set; }

    public int ComfortId { get; set; }

    public virtual Comfort Comfort { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
