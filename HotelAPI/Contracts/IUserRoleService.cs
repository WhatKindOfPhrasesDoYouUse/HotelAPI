using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IUserRoleService
    {
        Task<IEnumerable<object>> GetAllUsersRoles();
    }
}
