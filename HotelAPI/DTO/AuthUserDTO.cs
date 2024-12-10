using System.ComponentModel.DataAnnotations;

namespace HotelAPI.DTO
{
    public class AuthUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
