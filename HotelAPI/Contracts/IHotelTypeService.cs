using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IHotelTypeService
    {
        Task<IEnumerable<HotelType>> GetAllHotelTypes();
        Task<HotelType?> GetHotelTypeById(long id);
        //Task<bool> AddCard(Card card);
        //Task<bool> DeleteCardById(long id);
        //Task<bool> UpdateCard(Card card);
    }
}
