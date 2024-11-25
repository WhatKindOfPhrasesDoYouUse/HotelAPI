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
        /// Асинхронный метод для получения JSON списка всех карт и данных пользователя.
        /// </summary>
        /// <returns>Возвращает DTO список</returns>
        public async Task<IEnumerable<CardDTO>> GetAllCards() 
        {
            var cards = await _context.Cards
                .Include(c => c.UserAccount)
                .ToListAsync();

            var cardsDTO = new List<CardDTO>();

            foreach (var card in cards)
            {
                var cardDTO = new CardDTO
                {
                    Id = card.Id,
                    Name = card.Name,
                    Number = card.Number,
                    Date = card.Date,
                    UserAccount = null
                };

                if (card.UserAccount != null)
                {
                    var userAccountDTO = new UserAccountDTO
                    {
                        Id = card.UserAccount.Id,
                        FirstName = card.UserAccount.FirstName,
                        LastName = card.UserAccount.LastName,
                        Surname = card.UserAccount.Surname,
                        Email = card.UserAccount.Email,
                        PhoneNumber = card.UserAccount.PhoneNumber,
                        CardId = card.UserAccount.CardId
                    };

                    cardDTO.UserAccount = userAccountDTO;
                }

                cardsDTO.Add(cardDTO);
            }

            return cardsDTO;
        }

        /// <summary>
        /// Асинхронный метод для получения JSON объекта карты и данных пользователя.
        /// </summary>
        /// <returns>Возвращает DTO объект</returns>
        public async Task<CardDTO?> GetCardById(long id)
        {
            var card = await _context.Cards
                .Include(c => c.UserAccount)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (card == null)
            {
                return null;
            }

            var cardDTO = new CardDTO
            {
                Id = card.Id,
                Name = card.Name,
                Number = card.Number,
                Date = card.Date,
                UserAccount = null
            };

            if (card.UserAccount != null)
            {
                var userAccountDTO = new UserAccountDTO
                {
                    Id = card.UserAccount.Id,
                    FirstName = card.UserAccount.FirstName,
                    LastName = card.UserAccount.LastName,
                    Surname = card.UserAccount.Surname,
                    Email = card.UserAccount.Email,
                    PhoneNumber = card.UserAccount.PhoneNumber,
                    CardId = card.UserAccount.CardId
                };

                cardDTO.UserAccount = userAccountDTO;
            }

            return cardDTO;
        }

        /// <summary>
        /// Асинхронный метод для добавления новой карты в базу данных.
        /// </summary>
        /// <param name="card">Объект карты, который добавляется в базу данных.</param>
        /// <returns>Возвращает <c>true</c>, если карта успешно добавлена, или <c>false</c>, если карта с таким номером уже существует.</returns>
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
        /// Асинхронный метод для удаления карты из базы данных по ее id.
        /// Если карта привязана к учетной записи пользователя, ссылка на карту будет удалена из учетной записи.
        /// </summary>
        /// <param name="id">Идентификатор карты которую нужно удалить.</param>
        /// <returns>
        /// Возвращает <c>true</c>, если карта успешно удалена, или <c>false</c>, если карта с указанным идентификатором не найдена.
        /// </returns>
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
        /// Асинхронный метод для обновления данных существующей карты в базе данных.
        /// </summary>
        /// <param name="card">Объект обладающий обновленными полями.</param>
        /// <returns>
        /// Возвращает <c>true</c>, если обновление выполнено успешно, или <c>false</c>, если карта с указанным идентификатором не найдена.
        /// </returns>
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
