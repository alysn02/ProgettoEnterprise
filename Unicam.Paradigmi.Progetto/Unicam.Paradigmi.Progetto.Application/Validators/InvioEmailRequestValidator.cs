using FluentValidation;
using Unicam.Paradigmi.Progetto.Application.Models.Request;

namespace Unicam.Paradigmi.Progetto.Application.Validators
{
    public class InvioEmailRequestValidator : AbstractValidator<InvioEmailRequest>
    {
        public InvioEmailRequestValidator()
        {
            RuleFor(m => m.IdListaDestinatari)
                .NotNull()
                .WithMessage("Il campo è obbligatorio(nullo)")
                .NotEmpty()
                .WithMessage("il campo è obbligatorio(vuoto)");

            RuleFor(m => m.Subject)
                .NotNull()
                .WithMessage("Il campo è obbligatorio(nullo)")
                .NotEmpty()
                .WithMessage("il campo è obbligatorio(vuoto)");

            RuleFor(m => m.Body)
                .NotNull()
                .WithMessage("Il campo è obbligatorio(nullo)")
                .NotEmpty()
                .WithMessage("il campo è obbligatorio(vuoto)");
        }
    }
}
