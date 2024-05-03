using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Models.Dtos
{
    public class ListaUtenzaDto
    {
        public ListaUtenzaDto(ListaDistribuzione lista)
        {
            Nome = lista.Nome;
            IdProprietario = lista.IdProprietario;
        }
        public string Nome { get; set; } = string.Empty;
        public int IdProprietario { get; set; }

       
    }
}
