using AutoMapper;
using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.DTO;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    /// <summary>
    /// Сервис для управления комнатами в отеле.
    /// Предоставляет методы для получения информации о комнатах, их добавления, обновления и удаления.
    /// </summary>
    public class HotelReviewService : IHotelReviewService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор сервиса для работы с комнатами.
        /// </summary>
        /// <param name="context">Контекст базы данных для доступа к данным о комнатах.</param>
        /// <param name="mapper">Интерфейс AutoMapper для преобразования между моделями и DTO.</param>
        public HotelReviewService(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        // <summary>
        /// Получает все комнаты с информацией о бронированиях, удобствах и отеле.
        /// </summary>
        /// <returns>Список объектов <see cref="RoomDTO"/> с данными о всех комнатах отеля.</returns>
        public async Task<IEnumerable<HotelReviewDTO>> GetAllHotelReviews()
        {
            var hotelReviews = await _context.HotelReviews
                .Include(hr => hr.UserAccount)
                .Include(hr => hr.Hotel)
                .ToListAsync();

            return _mapper.Map<IEnumerable<HotelReviewDTO>>(hotelReviews);
        }


        /// <summary>
        /// Получает информацию о комнате по ее идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор комнаты.</param>
        /// <returns>Объект <see cref="RoomDTO"/> с данными о комнате, или <c>null</c>, если комната не найдена.</returns>
        public async Task<HotelReviewDTO?> GetHotelReviewById(long id)
        {
            var hotelReview = await _context.HotelReviews
                .Include(hr => hr.UserAccount)
                .Include(hr => hr.Hotel)
                .FirstOrDefaultAsync(hr => hr.Id == id);

            return _mapper.Map<HotelReviewDTO>(hotelReview);
        }

        public async Task<IEnumerable<HotelReviewDTO>> GetHotelReviewsByHotelId(long hotelId)
        {
            var reviews = await _context.HotelReviews
                .Where(review => review.HotelId == hotelId)
                .Include(review => review.Hotel)
                .Include(review => review.UserAccount)
                .Select(review => new HotelReviewDTO
                {
                    Id = review.Id,
                    Comment = review.Comment,
                    PublishDate = review.PublishDate,
                    Rating = review.Rating,
                    HotelId = review.HotelId,
                    UserAccountId = review.UserAccountId,
                    Hotel = new HotelSummaryDTO
                    {
                        Id = review.Hotel.Id,
                        Name = review.Hotel.Name
                    },
                    UserAccount = new UserAccountSummaryDTO
                    {
                        Id = review.UserAccount.Id,
                        FirstName = review.UserAccount.FirstName,
                        LastName = review.UserAccount.LastName
                    }
                })
                .ToListAsync();

            return reviews;
        }

        /// <summary>
        /// Добавляет новую комнату в базу данных.
        /// Проверяется уникальность номера комнаты в рамках отеля.
        /// </summary>
        /// <param name="room">Объект <see cref="Room"/> с данными о новой комнате.</param>
        /// <returns><c>true</c>, если комната успешно добавлена, иначе <c>false</c> (например, если такая комната уже существует в отеле).</returns>
        public async Task<bool> AddHotelReview(HotelReview hotelReview)
        {
            await _context.HotelReviews.AddAsync(hotelReview);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Обновляет информацию о комнате в базе данных.
        /// </summary>
        /// <param name="id">Идентификатор комнаты, которую необходимо обновить.</param>
        /// <param name="room">Объект <see cref="Room"/> с обновленными данными.</param>
        /// <returns><c>true</c>, если комната успешно обновлена, иначе <c>false</c> (например, если комната не найдена).</returns>
        public async Task<bool> UpdateHotelReview(long id, HotelReview hotelReview)
        {
            var existingHotelReveiw = await _context.HotelReviews.FirstOrDefaultAsync(hr => hr.Id == id);

            if (existingHotelReveiw == null)
            {
                return false;
            }

            existingHotelReveiw.Comment = hotelReview.Comment;
            existingHotelReveiw.PublishDate = hotelReview.PublishDate;
            existingHotelReveiw.Rating = hotelReview.Rating;
            existingHotelReveiw.HotelId = hotelReview.HotelId;
            existingHotelReveiw.UserAccountId = hotelReview.UserAccountId;

            await _context.SaveChangesAsync();

            return true;    
        }

        /// <summary>
        /// Удаляет комнату по ее идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор комнаты, которую нужно удалить.</param>
        /// <returns><c>true</c>, если комната успешно удалена, иначе <c>false</c> (например, если комната не найдена).</returns>
        public async Task<bool> DeleteHotelReviewById(long id)
        {
            var hotelReview = await _context.HotelReviews.FirstOrDefaultAsync(hr => hr.Id == id);

            if (hotelReview == null)
            {
                return false;
            }

            _context.HotelReviews.Remove(hotelReview);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
