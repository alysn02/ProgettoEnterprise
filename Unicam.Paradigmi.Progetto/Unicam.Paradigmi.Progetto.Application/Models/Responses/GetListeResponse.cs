using Unicam.Paradigmi.Progetto.Application.Models.Dtos;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Models.Responses
{
    public class GetListeResponse
    {
        public int NPagine { get; set; }
        public List<ListaUtenzaDto> Liste = new List<ListaUtenzaDto>();
    }
}
