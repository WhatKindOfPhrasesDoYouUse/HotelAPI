using HotelAPI.DTO;
using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IUserAccountService
    {
        Task<IEnumerable<UserAccountDTO>> GetAllUsers();
        Task<UserAccountDTO?> GetUserByEmail(string email);
        Task<UserAccount?> GetUserModelByEmail(string email);
        Task<UserAccountDTO?> GetUserById(long id);
        Task<UserAccountDTO?> GetUserByFirstNameAndLastName(string firstName, string lastName);
    }
}
