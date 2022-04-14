namespace FlashCards.Api.ViewModels
{
    public class CardViewModel
    {
        public int CardId { get; set; }
        public int DeckId { get; set; }
        public int MemorizationId { get; set; }
        public string? Backside { get; set; }
        public string? Frontside { get; set; }
    }
}
