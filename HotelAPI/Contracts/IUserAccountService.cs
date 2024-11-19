using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IUserAccountService
    {
        Task<IEnumerable<UserAccount>> GetAllUsers();
        Task<UserAccount?> GetUserByEmail(string email);
        Task<UserAccount?> GetUserById(long id);
        Task<UserAccount?> GetUserByFirstNameAndLastName(string firstName, string lastName);
    }
}
