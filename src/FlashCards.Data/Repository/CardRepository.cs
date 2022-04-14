
using FlashCards.Business.Interfaces;
using FlashCards.Business.Models;
using FlashCards.Data.Context;

namespace FlashCards.Data.Repository
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(FlashCardContext context) : base(context)
        {
        }
    }
}
