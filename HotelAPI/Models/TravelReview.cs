using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class TravelReview
{
    public int Id { get; set; }

    public string Comment { get; set; } = null!;

    public DateOnly PublishDate { get; set; }

    public int TravelId { get; set; }

    public int Rating { get; set; }

    public int UserAccountId { get; set; }

    public virtual Travel Travel { get; set; } = null!;

    public virtual UserAccount UserAccount { get; set; } = null!;
}
