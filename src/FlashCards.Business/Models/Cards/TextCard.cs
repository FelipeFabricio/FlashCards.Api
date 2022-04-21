namespace FlashCards.Business.Models.Cards
{
    public class TextCard : Card
    {
        public string Backside { get; set; }
        public string Frontside { get; set; }
        public int MemorizationId { get; set; }
        public Memorization Memorization { get; set; }
    }
}
