using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetAllCards();
        Task<Card?> GetCardById(long id);
        Task<bool> AddCard(Card card);
        Task<bool> DeleteCardById(long id);
        Task<bool> UpdateCard(Card card);
    }
}
