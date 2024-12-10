using AutoMapper;
using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.DTO;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    // TODO: 1. Вероятно стоит решить проблему странного хранения ролей и пользователей в JSON, но это не критично.
    // TODO: 2. Перенести Card и Role сервисы на маппер.
    // TODO: 3. Удаление, добавление и редактирование стоит сделать когда уже будет авторизация и регистрация.
    // TODO: 4. Переделать чуток JSON, а то получается какое - то очко, очень много дублирований данных.
    public class UserAccountService : IUserAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserAccountService(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<UserAccountDTO>> GetAllUsers()
        {
            var usersAccounts = await _context.UserAccounts
                .Include(u => u.Card)
                .Include(u => u.Roles)
                .Include(u => u.Bookings)
                .Include(u => u.HotelReviews)
                .Include(u => u.Hotels)
                .Include(u => u.RequestServices)
                .Include(u => u.RequestServiceReviews)
                .Include(u => u.PaymentTravels)
                .Include(u => u.TravelReviews)
                .ToListAsync();

            if (usersAccounts == null || !usersAccounts.Any())
            {
                return Enumerable.Empty<UserAccountDTO>();
            }

            return _mapper.Map<IEnumerable<UserAccountDTO>>(usersAccounts);
        }

        public async Task<UserAccountDTO?> GetUserById(long id)
        {
            var userAccount = await _context.UserAccounts
                .Include(u => u.Card)
                .Include(u => u.Roles)
                .Include(u => u.Bookings)
                .Include(u => u.HotelReviews)
                .Include(u => u.Hotels)
                .Include(u => u.RequestServices)
                .Include(u => u.RequestServiceReviews)
                .Include(u => u.PaymentTravels)
                .Include(u => u.TravelReviews)
                .FirstOrDefaultAsync(ua => ua.Id == id);

            if (userAccount == null)
            {
                return null;
            }

            return _mapper.Map<UserAccountDTO>(userAccount);
        }

        public async Task<UserAccountDTO?> GetUserByEmail(string email)
        {
            var userAccount = await _context.UserAccounts
                .Include(u => u.Card)
                .Include(u => u.Roles)
                .Include(u => u.Bookings)
                .Include(u => u.HotelReviews)
                .Include(u => u.Hotels)
                .Include(u => u.RequestServices)
                .Include(u => u.RequestServiceReviews)
                .Include(u => u.PaymentTravels)
                .Include(u => u.TravelReviews)
                .FirstOrDefaultAsync(ua => ua.Email == email);

            if (userAccount == null)
            {
                return null;
            }

            return _mapper.Map<UserAccountDTO>(userAccount);
        }

        public async Task<UserAccount?> GetUserModelByEmail(string email)
        {
            var userAccount = await _context.UserAccounts
                .Include(u => u.Card)
                .Include(u => u.Roles)
                .Include(u => u.Bookings)
                .Include(u => u.HotelReviews)
                .Include(u => u.Hotels)
                .Include(u => u.RequestServices)
                .Include(u => u.RequestServiceReviews)
                .Include(u => u.PaymentTravels)
                .Include(u => u.TravelReviews)
                .FirstOrDefaultAsync(ua => ua.Email == email);

            if (userAccount == null)
            {
                return null;
            }

            return userAccount;
        }

        public async Task<UserAccountDTO?> GetUserByFirstNameAndLastName(string firstName, string lastName)
        {
            var userAccount = await _context.UserAccounts
                .Include(u => u.Card)
                .Include(u => u.Roles)
                .Include(u => u.Bookings)
                .Include(u => u.HotelReviews)
                .Include(u => u.Hotels)
                .Include(u => u.RequestServices)
                .Include(u => u.RequestServiceReviews)
                .Include(u => u.PaymentTravels)
                .Include(u => u.TravelReviews)
                .FirstOrDefaultAsync(ua => ua.FirstName == firstName && ua.LastName == lastName);

            if (userAccount == null)
            {
                return null;
            }

            return _mapper.Map<UserAccountDTO>(userAccount);
        }
    }
}
