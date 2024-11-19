using HotelAPI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelTypeController : ControllerBase
    {
        private readonly IHotelTypeService _hotelTypeService;

        public HotelTypeController(IHotelTypeService hotelTypeService)
        {
            this._hotelTypeService = hotelTypeService;
        }

        [HttpGet("GetHotelTypes")]
        public async Task<IActionResult> GetHotelTypes()
        {
            var hotelTypes = await _hotelTypeService.GetAllHotelTypes();

            if (hotelTypes == null)
            {
                return NotFound("Типы отелей не найдены");
            }

            return Ok(hotelTypes);
        }
    }
}
