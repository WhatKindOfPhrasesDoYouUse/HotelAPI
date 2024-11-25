using HotelAPI.DTO;
using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface ICardService
    {
        Task<IEnumerable<CardDTO>> GetAllCards();
        Task<CardDTO?> GetCardById(long id);
        Task<bool> AddCard(Card card);
        Task<bool> DeleteCardById(long id);
        Task<bool> UpdateCard(Card card);
    }
}
