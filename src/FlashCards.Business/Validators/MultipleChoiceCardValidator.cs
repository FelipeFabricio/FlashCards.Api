using FlashCards.Business.Models.Cards;
using FluentValidation;

namespace FlashCards.Business.Validators
{
    public class MultipleChoiceCardValidator : AbstractValidator<MultipleChoiceCard>
    {
        public MultipleChoiceCardValidator()
        {
            RuleFor(d => d.Question)
                .NotNull().WithMessage("Esse campo é obrigatório.")
                .Length(5, 100);

            RuleFor(d => d.AnswerId)
                .NotNull().WithMessage("Esse campo é obrigatório.");

            RuleFor(d => d.DeckId)
                .NotNull().WithMessage("Esse campo é obrigatório.");
        }
    }
}
