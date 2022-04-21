using FlashCards.Business.Models.Cards;
using FluentValidation;

namespace FlashCards.Business.Validators
{
    public class TextCardValidator : AbstractValidator<TextCard>
    {
        public TextCardValidator()
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
