
using FlashCards.Business.Interfaces;
using FlashCards.Business.Models;
using FlashCards.Business.Models.Cards;
using FlashCards.Data.Context;

namespace FlashCards.Data.Repository
{
    public class MultipleChoiceCardRepository : Repository<MultipleChoiceCard>, IMultipleChoiceCardRepository
    {
        public MultipleChoiceCardRepository(FlashCardContext context) : base(context)
        {
        }
    }
}
