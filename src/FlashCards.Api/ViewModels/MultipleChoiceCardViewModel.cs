namespace FlashCards.Api.ViewModels
{
    public class MultipleChoiceCardViewModel
    {
        public int CardId { get; set; }
        public int DeckId { get; set; }
        public string Question { get; set; }
        public int AnswerId { get; set; }
        public List<ChoiceViewModel> Choices { get; set; }
    }
}
