
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    public class UtenteDto
    {
        public string Email { get; set; }=string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public UtenteDto(Utente utente) {
            Email = utente.Email;
            Nome= utente.Nome;
            Cognome = utente.Cognome;
            Password = utente.Password;
        }

    }
}
