using HotelAPI.DTO;

namespace HotelAPI.Contracts
{
    public interface IAuthService
    {
        Task<string> Login(AuthUserDTO loginDto);
    }
}
