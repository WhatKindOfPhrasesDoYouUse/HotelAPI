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

        /*[HttpGet("GetHotelTypes")]
        public async Task<IActionResult> GetHotelTypes()
        {
            var hotelTypes = await _hotelTypeService.GetAllHotelTypes();

            if (hotelTypes == null)
            {
                return NotFound();
            }

            return Ok(hotelTypes);
        }*/

        /*[HttpGet("GetHotelType/{id}")]
        public async Task<IActionResult> GetHotelType(long id)
        {
            if (id <= 0)
            {
                return NoContent();
            }

            var hotelType = await _hotelTypeService.GetHotelTypeById(id);

            if (hotelType == null)
            {
                return NotFound();
            }

            return Ok(hotelType);
        }*/
    }
}