using FlashCards.Business.Models;
using FluentValidation;

namespace FlashCards.Business.Validators
{
    public class MemorizationValidator : AbstractValidator<Memorization>
    {
        public MemorizationValidator()
        {
            RuleFor(m => m.MemorizationId)
                .NotNull().WithMessage("Esse campo é obrigatório.");

            RuleFor(m => m.Description)
                .NotNull()
                .Length(3, 20).WithMessage("Esse campo precisar ter entre 3 e 20 caracteres.");

            RuleFor(m => m.Level)
                .NotNull().WithMessage("Esse campo é obrigatório.");
        }
    }
}
