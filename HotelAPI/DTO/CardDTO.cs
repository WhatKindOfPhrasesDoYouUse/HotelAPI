namespace HotelAPI.DTO
{
    // TODO: Додумать реализацию через DTO (data transfer object)
    public class CardDTO
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Date { get; set; }
        public UserAccountDTO? UserAccount { get; set; }
    }
}
