namespace FlashCards.Business.Models.Cards
{
    public abstract class Card
    {
        public int CardId { get; set; }
        public int DeckId { get; set; }
        public Deck Deck { get; set; }
    }
}
