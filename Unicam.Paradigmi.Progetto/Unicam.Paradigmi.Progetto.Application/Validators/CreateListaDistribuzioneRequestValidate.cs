using FluentValidation;
using Unicam.Paradigmi.Application.Models.Request;
using Unicam.Paradigmi.Progetto.Application.Models.Request;

namespace Unicam.Paradigmi.Progetto.Application.Validators
{
    public class CreateListaDistribuzioneRequestValidator : AbstractValidator<CreateListaDistribuzioneRequest>
    {
        public CreateListaDistribuzioneRequestValidator()
        {

            RuleFor(m => m.Nome)
                .NotNull()
                .WithMessage("Il campo è obbligatorio(nullo)")
                .NotEmpty()
                .WithMessage("il campo è obbligatorio(vuoto)");

            RuleFor(m => m.IdProprietario)
                .NotNull()
                .WithMessage("Il campo è obbligatorio(nullo)")
                .NotEmpty()
                .WithMessage("il campo è obbligatorio(vuoto)");

        }
    }
}
