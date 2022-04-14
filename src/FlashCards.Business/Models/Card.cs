namespace FlashCards.Business.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public int DeckId { get; set; }
        public int MemorizationId { get; set; }
        public string? Backside { get; set; }
        public string? Frontside { get; set; }

        public Memorization Memorization { get; set; }
        public Deck Deck { get; set; }
    }
}
