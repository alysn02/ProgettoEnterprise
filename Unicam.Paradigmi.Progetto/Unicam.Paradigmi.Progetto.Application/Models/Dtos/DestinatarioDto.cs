using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Models.Dtos
{
    public class DestinatarioDto
    {
        public string email { get; set; }

        public DestinatarioDto (Destinatario destinatario){
            this.email = destinatario.Email;
            }

      
    }
}
