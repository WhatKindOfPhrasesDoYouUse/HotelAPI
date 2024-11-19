using HotelAPI.Contracts;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestServiceController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestServiceController(IRequestService requestService)
        {
            this._requestService = requestService;
        }

        [HttpGet("GetRequestServices")]
        public async Task<IActionResult> GetRequestServices()
        {
            var requestServices = await _requestService.GetAllRequestServices();

            if (requestServices == null)
            {
                return BadRequest("В списке нет запроса на такую услугу");
            }

            return Ok(requestServices);
        }
    }
}
