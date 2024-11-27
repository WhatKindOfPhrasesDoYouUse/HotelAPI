namespace HotelAPI.DTO
{
    public class UserRoleDTO
    {
        public long? UserId { get; set; }
        public long? RoleId { get; set; }
        public IEnumerable<long>? UserAccountsId { get; set; } = new List<long>();
    }
}
