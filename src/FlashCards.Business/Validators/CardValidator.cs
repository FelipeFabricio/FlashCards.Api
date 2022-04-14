using FlashCards.Business.Models;
using FluentValidation;

namespace FlashCards.Business.Validators
{
    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(d => d.Frontside)
                .NotNull().WithMessage("Esse campo é obrigatório.")
                .Length(1, 500);

            RuleFor(d => d.Backside)
                .NotNull().WithMessage("Esse campo é obrigatório.")
                .Length(1, 500).WithMessage("Esse campo precisa ter entre 1 e 500 caracteres.");

            RuleFor(d => d.MemorizationId)
                .NotNull().WithMessage("Esse campo é obrigatório.");

            RuleFor(d => d.DeckId)
                .NotNull().WithMessage("Esse campo é obrigatório.");
        }
    }
}
