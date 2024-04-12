using System.ComponentModel.DataAnnotations;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Request
{
    public class CreateUtenteRequest
    {
        //[Required(ErrorMessage ="campo ragione sociale obbligatorio")]
        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Cognome {  get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        public Utente ToEntity()
        {
            var utente =new Utente();
            utente.Email=Email;
            utente.Nome=Nome;
            utente.Cognome=Cognome;
            utente.Password = Password;
            return utente;
        }
    }
}
