using FlashCards.Business.Models;
using FluentValidation;

namespace FlashCards.Business.Validators
{
    public class DeckValidator : AbstractValidator<Deck>
    {
        public DeckValidator()
        {
            RuleFor(d => d.DeckId)
                .NotNull().WithMessage("Esse campo é obrigatório.");

            RuleFor(d => d.Description)
                .Length(1, 200).WithMessage("Esse campo precisar ter entre 1 e 200 caracteres."); ;

            RuleFor(d => d.Done)
                .NotNull().WithMessage("Esse campo é obrigatório.");

            RuleFor(d => d.Name)
                .NotNull().WithMessage("Esse campo é obrigatório.")
                .Length(1, 50).WithMessage("Esse campo precisar ter entre 1 e 50 caracteres.");
        }
    }
}
