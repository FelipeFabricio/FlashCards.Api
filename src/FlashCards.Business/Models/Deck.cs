using FlashCards.Business.Models.Cards;

namespace FlashCards.Business.Models
{
    public class Deck
    {
        public int DeckId { get; set; }
        public int User { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Done { get; set; }
        public IEnumerable<TextCard> Cards { get; set; }
    }
}
