using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly ApplicationDbContext _context;

        public UserAccountService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<UserAccount>> GetAllUsers()
        {
            var usersAccounts = await _context.UserAccounts.ToListAsync();

            if (usersAccounts != null || usersAccounts.Any())
            {
                return usersAccounts;
            }
            else
            {
                return null;
            }
        }

        public async Task<UserAccount?> GetUserByEmail(string email)
        {
            var user = await _context.UserAccounts.FirstOrDefaultAsync(x => x.Email == email);

            if (user != null) 
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<UserAccount?> GetUserById(long id)
        {
            var user = await _context.UserAccounts.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<UserAccount?> GetUserByFirstNameAndLastName(string firstName, string lastName)
        {
            var user = await _context.UserAccounts.FirstOrDefaultAsync(f => f.FirstName == firstName && f.LastName == lastName);

            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
