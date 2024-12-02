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
    /// </summary>
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        // TODO: В HotelSummaryDTO возможно стоит добавить отображение пользователя и типа отеля, а не только их ID. Не критично, но может и стоит это сделать.

        // <summary>
        /// Конструктор сервиса.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="mapper">Интерфейс AutoMapper для преобразования между моделями и DTO.</param>
        public RoomService(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        /// <summary>
        /// Получает все комнаты с информацией о бронированиях, удобствах и отеле.
        /// </summary>
        /// <returns>Список объектов <see cref="RoomDTO"/>.</returns>
        public async Task<IEnumerable<RoomDTO>> GetAllRooms()
        {
            var rooms = await _context.Rooms
                .Include(r => r.Bookings)
                .Include(r => r.Comforts)
                .Include(r => r.Hotel)
                .ToListAsync();

            return _mapper.Map<IEnumerable<RoomDTO>>(rooms);
        }

        /// <summary>
        /// Получает информацию о комнате по ее идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор комнаты.</param>
        /// <returns>Объект <see cref="RoomDTO"/> с данными о комнате или <c>null</c>, если комната не найдена.</returns>
        public async Task<RoomDTO?> GetRoomById(long id)
        {
            var room = await _context.Rooms
                .Include(r => r.Bookings)
                .Include(r => r.Hotel)
                .Include(r => r.Comforts)
                .FirstOrDefaultAsync(r => r.Id == id);

            return _mapper.Map<RoomDTO>(room);
        }

        /// <summary>
        /// Добавляет новую комнату в базу данных.
        /// </summary>
        /// <param name="room">Объект <see cref="Room"/> с данными о комнате, которую нужно добавить.</param>
        /// <returns><c>true</c>, если комната успешно добавлена, иначе <c>false</c> (например, если комната с таким номером уже существует в этом отеле).</returns>
        public async Task<bool> AddRoom(Room room)
        {
            // Обработка, для контроля уникальности комнат привязанных к отелю
            var findRoom = await _context.Rooms
                .FirstOrDefaultAsync(r => r.RoomNumber == room.RoomNumber && r.HotelId == room.HotelId);

            if (findRoom != null)
            {
                return false;
            }
            else
            {
                await _context.Rooms.AddAsync(room);
                await _context.SaveChangesAsync();

                return true;
            }
        }

        /// <summary>
        /// Обновляет информацию о комнате в базе данных.
        /// </summary>
        /// <param name="id">Идентификатор комнаты, которую нужно обновить.</param>
        /// <param name="room">Объект <see cref="Room"/> с обновленными данными.</param>
        /// <returns><c>true</c>, если комната успешно обновлена, иначе <c>false</c> (например, если комната с таким номером уже существует в этом отеле).</returns>
        public async Task<bool> UpdateRoom(long id, Room room)
        {
            var existingRoom = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);

            if (existingRoom == null) 
            {
                return false;
            }

            existingRoom.RoomType = room.RoomType;
            existingRoom.RoomNumber = room.RoomNumber;
            existingRoom.Capacity = room.Capacity;
            existingRoom.Description = room.Description;
            existingRoom.Price = room.Price;
            existingRoom.HotelId = room.HotelId;

            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Удаляет комнату по ее идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор комнаты, которую нужно удалить.</param>
        /// <returns><c>true</c>, если комната успешно удалена, иначе <c>false</c> (например, если комната с таким id не найдена).</returns>
        public async Task<bool> DeleteRoomById(long id)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(h => h.Id == id);

            if (room == null)
            {
                return false;
            }

            _context.RoomComforts.RemoveRange(room.Comforts);
            _context.Bookings.RemoveRange(room.Bookings);
            _context.Rooms.Remove(room);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
