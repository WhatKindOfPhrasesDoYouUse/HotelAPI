using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly ApplicationDbContext _context;

        public UserRoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetAllUsersRoles()
        {
            var result = await _context.UsersRoles
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .Select(ur => new
                {
                    UserId = ur.UserId,
                    RoleId = ur.Role.Id
                })
                .ToListAsync();

            return result;
        }
    }
}
