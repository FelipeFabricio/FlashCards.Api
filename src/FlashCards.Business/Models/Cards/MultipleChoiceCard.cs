namespace FlashCards.Business.Models.Cards
{
    public class MultipleChoiceCard : Card
    {
        public string Question { get; set; }
        public int AnswerId { get; set; }
        public ICollection<Choice> Choices { get; set; }
    }
}
