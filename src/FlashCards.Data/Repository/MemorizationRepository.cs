using FlashCards.Business.Interfaces;
using FlashCards.Business.Models;
using FlashCards.Data.Context;

namespace FlashCards.Data.Repository
{
    public class MemorizationRepository : Repository<Memorization>, IMemorizationRepository
    {
        public MemorizationRepository(FlashCardContext context) : base(context)
        {
        }
    }
}
