using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    /// <summary>
    /// TODO:
    /// 1. Доделать проверку на удаление
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            var roles = await _context.Roles.ToListAsync();

            if (roles != null || roles.Any())
            {
                return roles;
            }
            else
            {
                return null;
            }
        }

        public async Task<Role> GetRoleById(long id)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(x => x.Id == id);

            if (role == null)
            {
                return null;
            }

            return role;
        }

        public async Task<bool> AddRole(Role role)
        {
            var existingRole = await _context.Roles.SingleOrDefaultAsync(x => x.Id == role.Id || x.Name == role.Name);

            if (existingRole != null)
            {
                return false;
            }

            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

            return true;
        }

        /*public async Task<bool> DeleteRoleById(long id)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(x => x.Id == id);

            if (role == null)
            {
                return false;
            }


            var isActive = await UserRoleService.IsRoleUsed(id);

            return true;
        }*/
    }
}
