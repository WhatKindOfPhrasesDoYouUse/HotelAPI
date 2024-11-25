namespace HotelAPI.DTO
{
    public class UserAccountDTO
    {
        public long? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public long? CardId { get; set; }
        public CardDTO? Card { get; set; }
    }
}
