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
            var card = await _cardService.GetCardById(id);

            if (card == null)
            {
                return NotFound("Карта не найдена");
            }

            return Ok(card);
        }

        // Пофиксить метод добавления
        [HttpPost("AddCard")]
        public async Task<IActionResult> AddCard(Card card)
        {
            bool flag = await _cardService.AddCard(card);

            if (!flag)
            {
                return BadRequest("Не удалось добавить карту");
            }

            return Ok(card);
        }
    }
}
