using HotelAPI.DTO;
using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAllRoles();
        Task<RoleDTO?> GetRoleById(long id);
        Task<bool> AddRole(Role role);
        Task<bool> DeleteRoleById(long id);
        Task<bool> UpdateRole(Role role);
    }
}
