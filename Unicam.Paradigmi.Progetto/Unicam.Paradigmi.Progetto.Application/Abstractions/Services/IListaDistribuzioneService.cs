using Unicam.Paradigmi.Progetto.Models.Entities;
using Unicam.Paradigmi.Progetto.Models.Repositories;

namespace Unicam.Paradigmi.Progetto.Application.Abstractions.Services
{
    public interface IListaDistribuzioneService
    {
        public Task AddListaAsync(ListaDistribuzione lista);

        public Task<int> GetidProprietarioAsync(int idListaDistribuzione);


        public Task<(List<ListaDistribuzione>, int)> GetListeAsync(int idUtente, int tpXps, int ps, string? email);

        public Task<ListaDistribuzione> GetListaByNomeAsync(string nome);
       
    }
}
