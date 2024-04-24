using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Models.Dtos
{
    public class DestinatarioDto
    {
        public string Email { get; set; }

        public DestinatarioDto (Destinatario destinatario){
            this.Email = destinatario.Email;
            }

      
    }
}
