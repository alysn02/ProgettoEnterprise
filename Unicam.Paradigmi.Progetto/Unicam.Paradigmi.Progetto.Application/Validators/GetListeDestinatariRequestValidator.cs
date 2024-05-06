using FluentValidation;
using Unicam.Paradigmi.Progetto.Application.Models.Request;

namespace Unicam.Paradigmi.Progetto.Application.Validators
{
    public class GetListeDestinatariRequestValidator : AbstractValidator<GetListeDestinatariRequest>
    {
        public GetListeDestinatariRequestValidator()
        {
            RuleFor(request => request.PageSize)
                .GreaterThan(0)
                .WithMessage("Errore nella dimensione della pagina")
                .NotEmpty()
                .WithMessage("Non può essere vuoto")
                .NotNull()
                .WithMessage("Non può essere nullo");

            RuleFor(request => request.PageNumber)
                .GreaterThan(0)
                .WithMessage("Errore nel numero di pagina")
                .NotEmpty()
                .WithMessage("Non può essere vuoto")
                .NotNull()
                .WithMessage("Non può essere nullo");

            RuleFor(request => request.Email)
                .EmailAddress()
                .WithMessage("Errore nell'inserimento della mail")
                .NotEmpty()
                .WithMessage("Non può essere vuoto")
                .NotNull()
                .WithMessage("Non può essere nullo");
        }
    }
}
