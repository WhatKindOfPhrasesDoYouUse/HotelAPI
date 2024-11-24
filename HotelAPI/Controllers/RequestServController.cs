using HotelAPI.Contracts;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestServController : ControllerBase
    {
        private readonly IRequestServService _requestServService;

        public RequestServController(IRequestServService requestServService)
        {
            _requestServService = requestServService;
        }

        [HttpGet("GetRequestServices")]
        public async Task<IActionResult> GetRequestServices()
        {
            var requestServices = await _requestServService.GetAllRequestServices();

            if (requestServices == null)
            {
                return BadRequest();
            }

            return Ok(requestServices);
        }
    }
}
