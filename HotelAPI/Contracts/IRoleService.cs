using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> GetRoleById(long id);
        Task<bool> AddRole(Role role);
        //Task<bool> DeleteRoleById(long id);
    }
}
