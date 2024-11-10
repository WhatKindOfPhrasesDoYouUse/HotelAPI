using System;
using System.Collections.Generic;

namespace HotelAPI.Models;

public partial class RequestService
{
    public int Id { get; set; }

    public DateOnly RequestDate { get; set; }

    public TimeOnly RequestTime { get; set; }

    public string RequestStatus { get; set; } = null!;

    public string? AdditionalNotes { get; set; }

    public int QuantityRequests { get; set; }

    public int ServiceId { get; set; }

    public int UserAccountId { get; set; }

    public virtual ICollection<RequestServiceReview> RequestServiceReviews { get; set; } = new List<RequestServiceReview>();

    public virtual UserAccount Service { get; set; } = null!;

    public virtual UserAccount UserAccount { get; set; } = null!;
}
