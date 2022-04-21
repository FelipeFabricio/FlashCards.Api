
using FlashCards.Business.Interfaces;
using FlashCards.Business.Models;
using FlashCards.Business.Models.Cards;
using FlashCards.Data.Context;

namespace FlashCards.Data.Repository
{
    public class TextCardRepository : Repository<TextCard>, ITextCardRepository
    {
        public TextCardRepository(FlashCardContext context) : base(context)
        {
        }
    }
}
