using AutoMapper;
using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.DTO;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRoleService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Асинхронный метод для получения всех связей между пользователем и ролью.
        /// </summary>
        /// <returns>UserRoleDTO объект который содержит id обоих сущностей и так же данные полей объектов. 
        /// Если связанных объектов нет в таблце, то метод возвращает пустой список./// </returns>
        public async Task<IEnumerable<UserRoleDTO>> GetAllUsersRoles()
        {
            var result = await _context.UsersRoles
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .Select(ur => new UserRoleDTO
                {
                    UserId = ur.UserId,
                    RoleId = ur.Role.Id,
                    UserAccountSummary = new UserAccountSummaryDTO
                    {
                        Id = ur.User.Id,
                        FirstName = ur.User.FirstName,
                        LastName = ur.User.LastName,
                        Surname = ur.User.Surname,
                        Email = ur.User.Email,
                        PhoneNumber = ur.User.PhoneNumber
                    },
                    Role = new RoleDTO
                    {
                        Id = ur.Role.Id,
                        Name = ur.Role.Name
                    }
                })
                .ToListAsync();

            if (result == null && !result.Any())
            {
                return Enumerable.Empty<UserRoleDTO>();
            }

            return _mapper.Map<IEnumerable<UserRoleDTO>>(result);
        }

        /// <summary>
        /// Асинхронный метод для получения всех пользователей привязанных к определенной роли.
        /// </summary>
        /// <param name="id">Идентификатор роли, по которому производится поиск пользователей.</param>
        /// <returns>Если связанных объектов нет в таблце, то метод возвращает пустой список.</returns>
        public async Task<IEnumerable<UserRoleDTO>> GetUserByRoleId(long id)
        {
            var result = await _context.UsersRoles
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .Where(ur => ur.RoleId == id) 
                .Select(ur => new UserRoleDTO
                {
                    RoleId = ur.Role.Id,
                    UserAccountSummary = new UserAccountSummaryDTO
                    {
                        Id = ur.User.Id,
                        FirstName = ur.User.FirstName,
                        LastName = ur.User.LastName,
                        Surname = ur.User.Surname,
                        Email = ur.User.Email,
                        PhoneNumber = ur.User.PhoneNumber
                    }
                })
                .ToListAsync();

            return _mapper.Map<IEnumerable<UserRoleDTO>>(result);
        }

        
        public async Task<bool> AddRoleToUser(long userId, long roleId)
        {
            var user = await _context.UserAccounts.FirstOrDefaultAsync(u => u.Id == userId);
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);

            // Если не найден пользователь или роль
            if (user == null || role == null)
            {
                return false;
            }

            var existingUserRole = await _context.UsersRoles.FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            // Если такая связь уже существует
            if (existingUserRole != null)
            {
                return false;
            }

            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId,
                User = user,
                Role = role
            };

            _context.UsersRoles.Add(userRole);
            await _context.SaveChangesAsync();

            return true;
        }

        // TODO: сделать чеккер что бы если удаляем роль у пользователя у которого нет роли клиента, роль клиента добавлялась бы 1 раз
        public async Task<bool> RemoveRoleFromUser(long userId, long roleId) 
        {
            var userRole = await _context.UsersRoles.FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            // Если такая связь не найдена
            if (userRole == null)
            {
                return false;
            }

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "client");

            // Если у пользователя нет роли клиента, то присваиваем клиента. Так как для работы все таки нужна какая - то роль
            if (userRole.Role != role)
            {
                var clientRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "client");

                if (clientRole != null)
                {
                    var userClientRole = new UserRole
                    {
                        UserId = userId,
                        RoleId = clientRole.Id
                    };

                    _context.UsersRoles.Add(userClientRole);
                }
            }

            _context.UsersRoles.Remove(userRole);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
