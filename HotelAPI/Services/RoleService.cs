using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.DTO;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    /// <summary>
    /// RoleService реализует бизнес логику API для взаимодействия с ролями пользователя пользователей
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Асинхронный метод для получения ролией из базы данных, а так же списка пользователей обладающих данными ролями.
        /// </summary>
        /// <returns>Коллекция DTO объектов ролей.</returns>
        public async Task<IEnumerable<RoleDTO>> GetAllRoles()
        {
            var roles = await _context.Roles
                .Include(r => r.UserAccounts)
                .ToListAsync();

            var rolesDTO = new List<RoleDTO>();

            foreach (var role in roles)
            {
                var roleDTO = new RoleDTO
                {
                    Id = role.Id,
                    Name = role.Name,
                    UserAccountsId = new List<long>()
                };

                if (role.UserAccounts != null)
                {
                    foreach (var account in role.UserAccounts)
                    {
                        roleDTO.UserAccountsId.Add(account.UserId);
                    }
                }

                rolesDTO.Add(roleDTO);
            }

            return rolesDTO;
        }

        /// <summary>
        /// Асинхронный метод для получения роли из базы данных, а так же списка пользователей обладающих данной ролью.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DTO объект роли</returns>
        public async Task<RoleDTO> GetRoleById(long id)
        {
            var role = await _context.Roles
                .Include(r => r.UserAccounts)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (role == null)
            {
                return null;
            }

            var roleDTO = new RoleDTO
            {
                Id = role.Id,
                Name = role.Name,
                UserAccountsId = new List<long>()
            };
            
            if (role.UserAccounts != null)
            {
                foreach (var account in role.UserAccounts)
                {
                    roleDTO.UserAccountsId.Add(account.UserId);
                }
            }

            return roleDTO;
        }

        /// <summary>
        /// Асинхронный метод для добавления новой роли в базу данных.
        /// </summary>
        /// <param name="role">Объект роли, которую необходимо добавить.</param>
        /// <returns>Возвращает true, если роль успешно добавлена; иначе false (если роль с таким именем уже существует).</returns>
        public async Task<bool> AddRole(Role role)
        {
            var existingRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == role.Name);

            if (existingRole != null)
            {
                return false;
            }

            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

            return true;        
        }

        /// <summary>
        /// Асинхронный метод для удаления роли по идентификатору.
        /// Роль может быть удалена только в том случае, если она не связана с пользователями.
        /// </summary>
        /// <param name="id">Идентификатор роли, которую нужно удалить.</param>
        /// <returns>Возвращает true, если роль была успешно удалена; иначе false (если роль связана с пользователями или не найдена).</returns>
        public async Task<bool> DeleteRoleById(long id)
        {
            var role = await _context.Roles
                .Include(r => r.UserAccounts)
                .SingleOrDefaultAsync(r => r.Id == id);

            // Если роль не найдена
            if (role == null)
            {
                return false;
            }

            // Если роль связана с пользователями
            if (role.UserAccounts != null && role.UserAccounts.Count > 0)
            {
                return false;
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
