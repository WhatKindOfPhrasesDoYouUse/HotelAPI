using HotelAPI.Models;

namespace HotelAPI.Contracts
{
    public interface IHotelTypeService
    {
        Task<IEnumerable<HotelType>> GetAllHotelTypes();
    }
}
