using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class HotelType
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
