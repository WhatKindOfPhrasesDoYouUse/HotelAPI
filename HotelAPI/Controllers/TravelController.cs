using HotelAPI.Contracts;
using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    /// <summary>
    /// Контроллер для управления путешествиями.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly ITravelService _travelService;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TravelController"/> с указанным сервисом путешествий.
        /// </summary>
        /// <param name="travelService">Сервис для работы с путешествиями.</param>
        public TravelController(ITravelService travelService)
        {
            this._travelService = travelService;
        }

        /// <summary>
        /// Получает список всех доступных путешествий.
        /// </summary>
        /// <returns>
        /// HTTP-ответ с кодом 200 (OK) и списком путешествий, если они найдены.
        /// Если путешествия отсутствуют, возвращает код 404 (Not Found).
        /// </returns>
        [HttpGet("GetTravels")]
        public async Task<IActionResult> GetTravels()
        {
            var travels = await _travelService.GetAllTravels();

            if (travels == null)
            {
                return NotFound();
            }

            return Ok(travels);
        }
    }
}
