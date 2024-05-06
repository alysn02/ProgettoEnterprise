using Unicam.Paradigmi.Progetto.Application.Models.Dtos;

namespace Unicam.Paradigmi.Progetto.Application.Models.Responses
{
    public class GetListeResponse
    {
        
        public List<ListaUtenzaDto> Liste { get; set; } = new List<ListaUtenzaDto>();
        public int NPagine { get; set; }
    }
}
