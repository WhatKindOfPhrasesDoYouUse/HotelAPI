using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    /// <summary>
    /// CardService реализует бизнес логику API для взаимодействия с картами пользователей
    /// </summary>
    public class CardService : ICardService
    {
        private readonly ApplicationDbContext _context;

        public CardService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Card>> GetAllCards() 
        {
            var cards = await _context.Cards.ToListAsync();

            if (cards != null || cards.Any())
            {
                return cards;
            }
            else
            {
                return null;
            }
        }

        public async Task<Card?> GetCardById(long id)
        {
            var card = await _context.Cards.FindAsync(id);

            if (card == null)
            {
                return null;
            }
            else
            {
                return card;
            }
        }

        public async Task<bool> AddCard(Card card)
        {
            var findCard = await _context.Cards.FindAsync(card.Id);

            if (findCard != null || await _context.Cards.AnyAsync(c => c.Name == card.Name || c.Number == card.Number)) 
            {
                return false;
            }
            else
            {
                await _context.Cards.AddAsync(card);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
