using HotelAPI.Contracts;
using HotelAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            this._userAccountService = userAccountService;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsersAccounts()
        {
            var userAccounts = await _userAccountService.GetAllUsers();

            if (userAccounts == null)
            {
                return BadRequest("В списке нет карт");
            }

            return Ok(userAccounts);
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var userAccount = await _userAccountService.GetUserByEmail(email);

            if (userAccount == null)
            {
                return NotFound($"Не найден пользователь с таким email: {email}");
            }

            return Ok(userAccount);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var userAccount = await _userAccountService.GetUserById(id);

            if (userAccount == null)
            {
                return BadRequest($"Не найден пользователь с таким id: {id}");
            }

            return Ok(userAccount);
        }

        [HttpGet("GetByFirstAndLastName")]
        public async Task<IActionResult> GetUserByFirstNameAndLastName([FromQuery] string firstName, [FromQuery] string lastName)
        {
            var user = await _userAccountService.GetUserByFirstNameAndLastName(firstName, lastName);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound($"Пользователь с именем {firstName} {lastName} не найден.");
            }
        }
    }
}
