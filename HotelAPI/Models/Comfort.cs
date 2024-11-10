using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class Comfort
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
