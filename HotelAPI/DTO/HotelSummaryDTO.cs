﻿namespace HotelAPI.DTO
{
    /// <summary>
    /// Этот DTO объект необходимый дя передачи информации пользователя через CardDTO
    /// </summary>
    public class HotelSummaryDTO
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? Rating { get; set; }
        public long? ManagerId { get; set; }
        public long? HotelTypeId { get; set; }

    }
}
