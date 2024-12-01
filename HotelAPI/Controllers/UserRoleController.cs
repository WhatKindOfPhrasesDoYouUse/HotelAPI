using HotelAPI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            this._userRoleService = userRoleService;
        }

        [HttpGet("GetUsersRoles")]
        public async Task<IActionResult> GetAllUsersRoles()
        {
            var userRole = await _userRoleService.GetAllUsersRoles();

            if (userRole == null)
            {
                return NotFound();
            }

            return Ok(userRole);
        }

        [HttpGet("GetUsersByRoleId/{id}")]
        public async Task<IActionResult> GetUsersByRoleId(long id)
        {
            var userRole = await _userRoleService.GetUserByRoleId(id);

            if (!userRole.Any()) 
            {
                return NoContent();
            }

            return Ok(userRole);
        }

        // Вроде пашет
        [HttpPost("AddRoleToUser/{userId}/{roleId}")]
        public async Task<IActionResult> AddRoleToUser(long userId, long roleId)
        {
            var result = await _userRoleService.AddRoleToUser(userId, roleId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("DeleteRoleFromUser/{userId}/{roleId}")]
        public async Task<IActionResult> DeleteRoleFromUser(long userId, long roleId)
        {
            var result = await _userRoleService.RemoveRoleFromUser(userId, roleId);

            if (!result)
            {
                return NotFound();
            }

            // Если роль была удалена лучше вернуть 204 статус
            return NoContent();
        }
    }
}
