using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Application.Models.Request
{
    public class CreateListaDistribuzioneRequest
    {
        public string Nome { get; set; } = string.Empty;
        public int IdProprietario { get; set; }
        public ListaDistribuzione ToEntity()
        {
            var lista = new ListaDistribuzione();
            lista.Nome = Nome;
            lista.IdProprietario = IdProprietario;
            return lista;
        }
    }
}
