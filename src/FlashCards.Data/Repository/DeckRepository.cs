using FlashCards.Business.Interfaces;
using FlashCards.Business.Models;
using FlashCards.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.Data.Repository
{
    public class DeckRepository : Repository<Deck>, IDeckRepository
    {
        public DeckRepository(FlashCardContext context) : base(context)
        {
        }

        public async Task<Deck> GetDeckAndCards(int id)
        {
            return await dbSet.Where(d => d.DeckId == id).Include(d => d.Cards).FirstOrDefaultAsync();
        }

    }
}
