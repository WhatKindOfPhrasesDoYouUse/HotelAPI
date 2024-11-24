using HotelAPI.Contracts;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComfortController : ControllerBase
    {
        private readonly IComfortService _comfortService;

        public ComfortController(IComfortService service)
        {
            this._comfortService = service;
        }

        [HttpGet("GetComforts")]
        public async Task<IActionResult> GetCards()
        {
            var comforts = await _comfortService.GetAllComforts();

            if (comforts == null)
            {
                return BadRequest("Список дополнительных услуг комфорт отсутствует");
            }

            return Ok(comforts);
        }
    }
}
