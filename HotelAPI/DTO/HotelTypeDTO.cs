﻿using HotelAPI.Models;

namespace HotelAPI.DTO
{
    public class HotelTypeDTO
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<HotelSummaryDTO> HotelSummaries { get; set; } = new List<HotelSummaryDTO>();
    }
}
