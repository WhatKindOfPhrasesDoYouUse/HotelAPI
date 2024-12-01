using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using HotelAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    /// <summary>
    /// Контролер обрабатывающий url запросы для управления картами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            this._cardService = cardService;
        }

        // <summary>
        /// Возвращает список всех карт.
        /// </summary>
        /// <returns>Результат выполнения запроса с данными карт.</returns>
        /// <response code="200">Список карт успешно получен.</response>
        /// <response code="400">Ошибка при получении данных карт.</response>
        [HttpGet("GetCards")]
        public async Task<IActionResult> GetCards()
        {
            var cards= await _cardService.GetAllCards();

            if (cards == null)
            {
                return BadRequest("Ошибка при получении данных карт"); 
            }

            return Ok(cards);
        }

        /// <summary>
        /// Возвращает карту по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор карты.</param>
        /// <returns>Результат выполнения запроса с данными карты.</returns>
        /// <response code="200">Карта успешно найдена и возвращена.</response>
        /// <response code="400">Некорректный идентификатор карты.</response>
        /// <response code="404">Карта с указанным идентификатором не найдена.</response>
        [HttpGet("GetCardById/{id}")]
        public async Task<IActionResult> GetCard(long id)
        {
            if (id <= 0)
            {
                return NoContent();
            }

            var card = await _cardService.GetCardById(id);

            if (card == null)
            {
                return NotFound("Карта не найдена");
            }

            return Ok(card);
        }

        /// <summary>
        /// Добавляет новую карту в систему.
        /// </summary>
        /// <param name="card">Объект карты, который нужно добавить.</param>
        /// <returns>Результат добавления карты.</returns>
        /// <response code="201">Карта успешно добавлена.</response>
        /// <response code="400">Некорректные данные карты (например, пустое тело запроса или некорректный формат данных).</response>
        /// <response code="409">Карта с таким номером или именем уже существует.</response>
        [HttpPost("AddCard")]
        public async Task<IActionResult> AddCard(Card card)
        {
            if (card == null)
            {
                return BadRequest("Некоректнные данные карты");
            }

            bool result = await _cardService.AddCard(card);

            if (!result)
            {
                return Conflict("Карта с таким номером или именем уже существует");
            }

            return CreatedAtAction(nameof(GetCard), new { id = card.Id }, card);
        }

        /// <summary>
        /// Удаляет карту по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор карты.</param>
        /// <returns>Результат удаления карты.</returns>
        /// <response code="200">Карта успешно удалена.</response>
        /// <response code="400">Некорректный идентификатор карты.</response>
        /// <response code="404">Карта с указанным идентификатором не найдена.</response>
        [HttpDelete("DeleteCardById/{id}")]
        public async Task<IActionResult> DeleteCardById(long id)
        {
            if (id <= 0)
            {
                return BadRequest("Некоректный ID");
            }

            bool isDeleted = await _cardService.DeleteCardById(id);

            if (!isDeleted)
            {
                return NotFound($"Карта с id: {id} не найдена");
            }

            return Ok($"Карта с id: {id} была успешно удалена");
        }

        // TODO: Переделать для обновления карты по 2 параметрам id, Card obj

        /// <summary>
        /// Обновляет информацию о карте.
        /// </summary>
        /// <param name="card">Объект карты с обновленными данными.</param>
        /// <returns>Результат обновления карты.</returns>
        /// <response code="200">Карта успешно обновлена.</response>
        /// <response code="400">Некорректные данные карты.</response>
        /// <response code="404">Карта с указанным идентификатором не найдена.</response>
        [HttpPut("UpdateCard")]
        public async Task<IActionResult> UpdateCard([FromBody] Card card)
        {
            if (card == null || card.Id <= 0)
            {
                return BadRequest("Введены некоректные данные");
            }

            bool isUpdated = await _cardService.UpdateCard(card);

            if (!isUpdated)
            {
                return NotFound($"Карта с id: {card.Id} не найдена");
            }

            return Ok($"Карта с ID {card.Id} успешно обновлена.");
        }
    }
}
