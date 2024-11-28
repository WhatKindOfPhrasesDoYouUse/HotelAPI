namespace HotelAPI.DTO
{
    public class UserRoleDTO
    {
        public long? UserId { get; set; }
        public long? RoleId { get; set; }
        public UserAccountSummaryDTO? UserAccountSummary { get; set; }
        public RoleDTO? Role { get; set; }
    }
}
