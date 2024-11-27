using AutoMapper;
using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.DTO;
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

        /// <summary>
        /// Асинхронно получает список всех карт с информацией о пользователе.
        /// </summary>
        /// <returns>
        /// Возвращает коллекцию объектов <see cref="CardDTO"/> содержащий информацию о картах и краткую информацию о пользователе карты.
        /// Если карты нет, то возвращает пустой список.
        /// </returns>
        /// <remarks>
        /// Получание только с роли админа.
        /// </remarks>
        public async Task<IEnumerable<CardDTO>> GetAllCards()
        {
            var cards = await _context.Cards
                .Include(c => c.UserAccount)
                .Select(c => new CardDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Number = c.Number,
                    Date = c.Date,
                    UserAccountSummary = new UserAccountSummaryDTO
                    {
                        Id = c.UserAccount.Id,
                        FirstName = c.UserAccount.FirstName,
                        LastName = c.UserAccount.LastName,
                        Surname = c.UserAccount.Surname,
                        Email = c.UserAccount.Email,
                        PhoneNumber = c.UserAccount.PhoneNumber
                    }
                }).ToListAsync();

            return cards;
        }

        /// <summary>
        /// Асинхронно получает информацию о карте по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор карты.</param>
        /// <returns>
        /// Возвращает объект <see cref="CardDTO"/>, содержащий информацию о карте и краткую информацию пользователе карты.
        /// Если карта с указанным идентификатором не найдена, возвращает <c>null</c>.
        /// </returns>
        /// <remarks>
        /// Метод должен в будующем находить залогинненого пользователя, и возвращать информацию о нем.
        /// </remarks>
        public async Task<CardDTO?> GetCardById(long id)
        {
            var card = await _context.Cards
                .Include(c => c.UserAccount)
                .Where(c => c.Id == id)
                .Select(c => new CardDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Number = c.Number,
                    Date = c.Date,
                    UserAccountSummary = new UserAccountSummaryDTO
                    {
                        Id = c.UserAccount.Id,
                        FirstName = c.UserAccount.FirstName,
                        LastName = c.UserAccount.LastName,
                        Surname = c.UserAccount.Surname,
                        Email = c.UserAccount.Email,
                        PhoneNumber = c.UserAccount.PhoneNumber
                    }
                })
                .FirstOrDefaultAsync();

            return card;
        }

        /// <summary>
        /// Асинхронный метод для удаления карты из базы данных по ее id.
        /// Если карта привязана к учетной записи пользователя, ссылка на карту будет удалена из учетной записи.
        /// </summary>
        /// <param name="id">Идентификатор карты которую нужно удалить.</param>
        /// <returns>
        /// Возвращает <c>true</c>, если карта успешно удалена, или <c>false</c>, если карта с указанным идентификатором не найдена.
        /// </returns>
        /// <remarks>
        /// Метод в будующем должен работать для залогиненого пользователя, что бы он мог отвязать карту.
        /// </remarks>
        public async Task<bool> DeleteCardById(long id)
        {
            var card = await _context.Cards.SingleOrDefaultAsync(c => c.Id == id);

            if (card == null)
            {
                return false;
            }

            var userAccount = await _context.UserAccounts.SingleOrDefaultAsync(u => u.CardId == card.Id);

            if (userAccount != null) 
            {
                userAccount.CardId = null;
                _context.UserAccounts.Update(userAccount);
            }

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Асинхронный метод для добавления новой карты в базу данных.
        /// </summary>
        /// <param name="card">Объект карты, который добавляется в базу данных.</param>
        /// <returns>Возвращает <c>true</c>, если карта успешно добавлена, или <c>false</c>, если карта с таким номером уже существует.</returns>
        /// <remarks>
        /// Метод в будующем должен работать для залогиненого пользователя, что бы он мог приявязать карту.
        /// </remarks>
        public async Task<bool> AddCard(Card card)
        {
            var existingCard = await _context.Cards.FirstOrDefaultAsync(c => c.Number == card.Number);

            if (existingCard != null)
            {
                return false;
            }
            
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Асинхронный метод для обновления данных существующей карты в базе данных.
        /// </summary>
        /// <param name="card">Объект обладающий обновленными полями.</param>
        /// <returns>
        /// Возвращает <c>true</c>, если обновление выполнено успешно, или <c>false</c>, если карта с указанным идентификатором не найдена.
        /// </returns>
        /// <remarks>
        /// Метод предназначен только залогиненого пользователя, что бы он мог редактировать свою карту.
        /// </remarks>
        public async Task<bool> UpdateCard(Card card)
        {
                var existingCard = await _context.Cards
                    .Include(c => c.UserAccount)
                    .SingleOrDefaultAsync(c => c.Id == card.Id);

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
