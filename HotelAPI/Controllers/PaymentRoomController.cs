using HotelAPI.Contracts;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentRoomController : ControllerBase
    {
        private readonly IPaymentRoomService _paymentRoomService;

        public PaymentRoomController(IPaymentRoomService paymentRoomService)
        {
            this._paymentRoomService = paymentRoomService;
        }

        [HttpGet("GetPaymentRooms")]
        public async Task<IActionResult> GetPaymentRooms()
        {
            var paymentRooms = await _paymentRoomService.GetAllPaymentRooms();

            if (paymentRooms == null)
            {
                return BadRequest("В списке нет оплат за комнату");
            }

            return Ok(paymentRooms);
        }
    }
}
