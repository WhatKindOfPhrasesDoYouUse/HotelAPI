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
                return NotFound();
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

        [HttpDelete("DeleteRoleById/{id}")]
        public async Task<IActionResult> DeleteRole(long id)
        {
            bool result = await _roleService.DeleteRoleById(id);

            if (!result)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(Role role)
        {
            // Некоректный запрос
            if (role == null)
            {
                return BadRequest();
            }

            bool result = await _roleService.AddRole(role);
            
            // Такая роль уже существует
            if (!result)
            {
                return Conflict();
            }

            return CreatedAtAction(nameof(AddRole), new { id = role.Id }, role);
        }
    }
}
