using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Contracts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceHandlerController : ControllerBase
    {
        private readonly IServiceHandler _serviceHandler;

        public ServiceHandlerController(IServiceHandler serviceHandler)
        {
            this._serviceHandler = serviceHandler;
        }

        [HttpGet("GetServices")]
        public async Task<IActionResult> GetServices()
        {
            var services = await _serviceHandler.GetAllServices();

            if (services == null)
            {
                return BadRequest("В списке нет сервисных услуг");
            }

            return Ok(services);
        }
    }
}
