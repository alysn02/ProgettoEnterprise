using System.Globalization;

namespace Unicam.Paradigmi.Progetto.Application.Models.Request
{
    public class GetListeDestinatariRequest
    {
        public int PageSize { get; set; } //Rappresenta la grandezza della pagina
        public int PageNumber { get; set; } //Identifica il numero della pagina ad indice 0
        public string Email { get; set; } = string.Empty; 
    }
}
