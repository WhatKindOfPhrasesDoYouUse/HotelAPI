using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class Service
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int HotelId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
