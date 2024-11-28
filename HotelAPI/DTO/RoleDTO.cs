namespace HotelAPI.DTO
{
    public class RoleDTO
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        // Лучше бы отказаться от этого списка
        public List<long>? UserAccountsId { get; set; } = new List<long>();
    }
}
