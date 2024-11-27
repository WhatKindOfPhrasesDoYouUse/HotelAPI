namespace HotelAPI.DTO
{
    public class RoleDTO
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public List<long>? UserAccountsId { get; set; } = new List<long>();
    }
}
