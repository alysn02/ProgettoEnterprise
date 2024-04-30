using FluentValidation;
using Unicam.Paradigmi.Application.Models.Request;
using Unicam.Paradigmi.Progetto.Application.Extensions;
using Unicam.Paradigmi.Progetto.Application.Models.Request;

namespace Unicam.Paradigmi.Progetto.Application.Validators
{
    public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
    {
        public CreateTokenRequestValidator()
        {
            RuleFor(m => m.Email)
                .EmailAddress()
                .WithMessage("Indirizzo email non valido")
                .NotNull()
                .WithMessage("Il campo è obbligatorio(nullo)")
                .NotEmpty()
                .WithMessage("il campo è obbligatorio(vuoto)");

            RuleFor(r => r.Password)
              .NotEmpty()
              .WithMessage("è obbligatorio")
              .NotNull()
              .WithMessage("non puo essere nullo")
              .MinimumLength(6)
              .WithMessage("deve essere lunga almeno 6 caratteri")
              .RegEx("^(?=.[A-Z])(?=.[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\-]).{6,}$",
              "il campo deve contenere almeno un carattere speciale, una lettera maiuscola, uno minuscolo");

        }
    }
}