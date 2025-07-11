using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleMAUI.BLL.DTOs.In;
using SimpleMAUI.BLL.DTOs.Out;
using SimpleMAUI.BLL.Helper;
using SimpleMAUI.BLL.Models;

namespace SimpleMAUI.BLL.Managers
{
    public class CardManager
    {
        private readonly SimpleMAUIDbContext _context;
        private readonly IMapper _mapper;

        public SimpleMAUIDbContext Context
        {
            get
            {
                return _context;
            }
        }

        public CardManager(SimpleMAUIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CardOutDto>> GetAllCardsAsync()
        {
            var cards = await _context.Cards.ToListAsync();
            return _mapper.Map<List<CardOutDto>>(cards);
        }
        public async Task<CardOutDto> GetCardByIdAsync(Guid id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                throw new KeyNotFoundException($"Card with ID {id} not found.");
            }
            return _mapper.Map<CardOutDto>(card);
        }
        public async Task AddCardAsync(CardInDto card)
        {
            var cardEntity = _mapper.Map<Card>(card);
            cardEntity.Id = Guid.NewGuid();
            _context.Cards.Add(cardEntity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCardAsync(CardInDto card, Guid id)
        {
            var existingCard = await _context.Cards.FindAsync(id);
            if (existingCard == null)
            {
                throw new KeyNotFoundException($"Card with ID {id} not found.");
            }
            existingCard.Title = card.Title;
            existingCard.Text = card.Text;
            existingCard.Image = card.Image;

            _context.Cards.Update(existingCard);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCardAsync(Guid id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card != null)
            {
                _context.Cards.Remove(card);
                await _context.SaveChangesAsync();
            }
        }
    }
}
