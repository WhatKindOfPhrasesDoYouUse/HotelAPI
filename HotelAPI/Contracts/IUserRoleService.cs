using HotelAPI.DTO;
using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRoleDTO>> GetAllUsersRoles();
        Task<IEnumerable<UserRoleDTO>> GetUserByRoleId(long id);
    }
}
