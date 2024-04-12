using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Models.Dtos
{
    public class ListaUtenzaDto
    {
        public string Nome { get; set; } = string.Empty;
        public string EmailProprietario { get; set; } = string.Empty;

        public ListaUtenzaDto(ListaUtenza lista)
        {
            Nome = lista.Nome;
            EmailProprietario = lista.EmailProprietario;
        }
    }
}
