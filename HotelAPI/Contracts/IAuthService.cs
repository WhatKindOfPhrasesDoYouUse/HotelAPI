using HotelAPI.DTO;
using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IAuthService
    {
        Task<string> Login(AuthUserDTO loginDto);
    }
}
