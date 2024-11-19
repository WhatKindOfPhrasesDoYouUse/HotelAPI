using HotelAPI.Contracts;
using HotelAPI.Models;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetAllRoles();

            if (roles == null)
            {
                return BadRequest("В списке нет ролей");
            }

            return Ok(roles);
        }

        [HttpGet("GetRole/{id}")]
        public async Task<IActionResult> GetRoleById(long id)
        {
            var role = await _roleService.GetRoleById(id);

            if (role == null)
            {
                return BadRequest($"Роль с id: {id} не существует");
            }

            return Ok(role);
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(Role role)
        {
            if (role == null)
            {
                return BadRequest("Некоректные данные");
            }

            bool result = await _roleService.AddRole(role);

            if (!result)
            {
                return Conflict("Такая роль уже существует");
            }

            return CreatedAtAction(nameof(AddRole), new { id = role.Id }, role);
        }
    }
}
