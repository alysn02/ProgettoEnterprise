using FluentValidation;
using Unicam.Paradigmi.Progetto.Application.Models.Request;

namespace Unicam.Paradigmi.Progetto.Application.Validators
{
    public class DeleteDestinatarioRequestValidator : AbstractValidator<DeleteDestinatarioRequest>
    {
        public DeleteDestinatarioRequestValidator()
        {
            RuleFor(i => i.IdLista)
                .NotNull()
                .WithMessage("Il campo è obbligatorio(id è nullo)")
                .NotEmpty()
                .WithMessage("il campo è obbligatorio(id è vuoto)");

            RuleFor(m => m.Email)
                .EmailAddress()
                .WithMessage("Indirizzo email non valido")
                .NotNull()
                .WithMessage("Il campo è obbligatorio(nullo)")
                .NotEmpty()
                .WithMessage("il campo è obbligatorio(vuoto)");

            RuleFor(m => m.NomeLista)
                .NotNull()
                .WithMessage("Il campo è obbligatorio(nullo)")
                .NotEmpty()
                .WithMessage("il campo è obbligatorio(vuoto)");
        }
    }
}
