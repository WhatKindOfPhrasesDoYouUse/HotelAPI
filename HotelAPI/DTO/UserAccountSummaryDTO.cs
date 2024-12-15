namespace HotelAPI.DTO
{
    /// <summary>
    /// Этот DTO объект необходимый дя передачи информации пользователя через CardDTO
    /// </summary>
    public class UserAccountSummaryDTO
    {
        public long? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; } = null!;
        public string? Passport { get; set; } = null!;
    }
}
