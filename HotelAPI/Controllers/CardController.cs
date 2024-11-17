using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using HotelAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            this._cardService = cardService;
        }

        [HttpGet("GetCards")]
        public async Task<IActionResult> GetCards()
        {
            var cards = await _cardService.GetAllCards();

            if (cards == null)
            {
                return BadRequest("В списке нет карт"); 
            }

            return Ok(cards);
        }

        [HttpGet("GetCardById/{id}")]
        public async Task<IActionResult> GetCard(long id)
        {
            if (id <= 0)
            {
                return BadRequest("Некоректный ID");
            }

            var card = await _cardService.GetCardById(id);

            if (card == null)
            {
                return NotFound("Карта не найдена");
            }

            return Ok(card);
        }

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

            return CreatedAtAction(nameof(GetCard), new {id = card.Id}, card);
        }

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
