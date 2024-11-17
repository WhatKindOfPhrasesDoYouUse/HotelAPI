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
            var existingCard = await _context.Cards.FirstOrDefaultAsync(c => c.Name == card.Name || c.Number == card.Number);

            if (existingCard != null)
            {
                return false;
            }
            
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCardById(long id)
        {
            var card = await _context.Cards.SingleOrDefaultAsync(c => c.Id == id);

            if (card == null)
            {
                return false;
            }

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCard(Card card)
        {
            var existingCard = await _context.Cards.SingleOrDefaultAsync(c => c.Id == card.Id);

            if (existingCard == null) 
            {
                return false;
            }

            existingCard.Number = card.Number;
            existingCard.Name = card.Name;
            existingCard.Date = card.Date;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
