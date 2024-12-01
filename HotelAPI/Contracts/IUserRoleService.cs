using HotelAPI.DTO;

namespace HotelAPI.Contracts
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRoleDTO>> GetAllUsersRoles();
        Task<IEnumerable<UserRoleDTO>> GetUserByRoleId(long id);
        Task<bool> AddRoleToUser(long userId, long roleId);
        Task<bool> RemoveRoleFromUser(long userId, long roleId);
    }
}
