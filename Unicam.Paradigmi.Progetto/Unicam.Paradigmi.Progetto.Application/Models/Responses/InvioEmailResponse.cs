using Unicam.Paradigmi.Progetto.Application.Models.Dtos;

namespace Unicam.Paradigmi.Progetto.Application.Models.Responses
{
    public class InvioEmailResponse
    {
        public List<DestinatarioDto> Destinatari { get; set; } =  new List<DestinatarioDto> ();
    }
}
