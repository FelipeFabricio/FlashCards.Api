namespace FlashCards.Api.ViewModels
{
    public class DeckViewModel
    {
        public int DeckId { get; set; }
        public int User { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Done { get; set; }
        public List<CardViewModel> Cards { get; set; }
    }
}
