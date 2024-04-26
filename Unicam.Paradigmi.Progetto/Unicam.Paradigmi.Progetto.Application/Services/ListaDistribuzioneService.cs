using Unicam.Paradigmi.Progetto.Application.Abstractions.Services;
using Unicam.Paradigmi.Progetto.Models.Entities;
using Unicam.Paradigmi.Progetto.Models.Repositories;

namespace Unicam.Paradigmi.Progetto.Application.Services
{
    public class ListaDistribuzioneService : IListaDistribuzioneService
    {
        private readonly ListaDistribuzioneRepository _listaDistribuzioneRepository;
        public ListaDistribuzioneService(ListaDistribuzioneRepository listaDistribuzioneRepository)
        {
            _listaDistribuzioneRepository = listaDistribuzioneRepository;
        }
        public async Task AddListaAsync(ListaDistribuzione lista)
        {
            await _listaDistribuzioneRepository.AggiungiAsync(lista);
            await _listaDistribuzioneRepository.SaveAsync();
        }
        public async Task<int> GetidProprietarioAsync(int idListaDistribuzione)
        {
            return await _listaDistribuzioneRepository.GetIdFromListaAsync(idListaDistribuzione);
        }

        public async Task<(List<ListaDistribuzione>,int)> GetListeAsync(int idUtente, int tpXps,int ps, string? email)
        {
            return await _listaDistribuzioneRepository.GetListeAsync(idUtente, tpXps,  ps, email);
        }

        public async Task<ListaDistribuzione> GetListaByNomeAsync(string nome)
        {
            return await _listaDistribuzioneRepository.GetListaByNomeAsync(nome);
        }
    }
}
