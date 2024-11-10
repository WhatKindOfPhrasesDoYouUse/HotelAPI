using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class HotelReview
{
    public int Id { get; set; }

    public string Comment { get; set; } = null!;

    public DateOnly PublishDate { get; set; }

    public int Rating { get; set; }

    public int HotelId { get; set; }

    public int UserAccountId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual UserAccount UserAccount { get; set; } = null!;
}
