using FluentValidation;
using Unicam.Paradigmi.Application.Models.Request;
using Unicam.Paradigmi.Progetto.Application.Models.Request;
namespace Unicam.Paradigmi.Progetto.Application.Validators
{
    public class AddDestinatarioRequestValidator : AbstractValidator<AddDestinatarioRequest>
    {
        public AddDestinatarioRequestValidator()
        {
            RuleFor(x => x.IdLista).NotEmpty().WithMessage("id non valido");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email non può essere vuota");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email non è valida");
        }
    }
}
