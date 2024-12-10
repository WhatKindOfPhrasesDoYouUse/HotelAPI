using HotelAPI.Contracts;
using HotelAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthUserDTO loginDto)
        {
            var result = await _authService.Login(loginDto);
            return Ok(result);
        }
    }
}
