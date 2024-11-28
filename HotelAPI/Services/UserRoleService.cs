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
    }
}
