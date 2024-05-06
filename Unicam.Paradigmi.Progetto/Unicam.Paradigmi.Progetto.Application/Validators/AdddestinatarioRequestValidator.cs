using FluentValidation;
using Unicam.Paradigmi.Progetto.Application.Models.Request;
namespace Unicam.Paradigmi.Progetto.Application.Validators
{
    public class AddDestinatarioRequestValidator : AbstractValidator<AddDestinatarioRequest>
    {
        public AddDestinatarioRequestValidator()
        {
            RuleFor(x => x.IdListaDistribuzione)
                .NotEmpty()
                .WithMessage("id non valido");
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email non è valida")
                .NotEmpty()
                .WithMessage("Email non può essere vuota");
        }
    }
}
