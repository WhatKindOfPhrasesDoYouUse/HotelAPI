using HotelAPI.Contracts;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTravelController : ControllerBase
    {
        private readonly IPaymentTravelService _paymentTravelService;

        public PaymentTravelController(IPaymentTravelService paymentTravelService)
        {
            this._paymentTravelService = paymentTravelService;
        }

        [HttpGet("GetPaymentTravels")]
        public async Task<IActionResult> GetPaymentTravels()
        {
            var paymentTravels = await _paymentTravelService.GetAllPaymentTravels();

            if (paymentTravels == null)
            {
                return NotFound();
            }

            return Ok(paymentTravels);
        }
    }
}
