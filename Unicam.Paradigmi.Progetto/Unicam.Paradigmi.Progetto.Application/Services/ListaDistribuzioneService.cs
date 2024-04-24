using Unicam.Paradigmi.Progetto.Models.Entities;
using Unicam.Paradigmi.Progetto.Models.Repositories;

namespace Unicam.Paradigmi.Progetto.Application.Services
{
    public class ListaDistribuzioneService
    {
        private readonly ListaDistribuzioneRepository _listaDistribuzioneRepository;
        public ListaDistribuzioneService(ListaDistribuzioneRepository listaDistribuzioneRepository)
        {
            _listaDistribuzioneRepository = listaDistribuzioneRepository;
        }
        public async Task AddListaAsync(ListaDistribuzione lista)
        {
            _listaDistribuzioneRepository.Aggiungi(lista);
            _listaDistribuzioneRepository.Save();
        }
        public async Task<int> GetidProprietarioAsync(int idListaDistribuzione)
        {
            return _listaDistribuzioneRepository.GetIdFromLista(idListaDistribuzione);
        }

        public async Task<List<ListaDistribuzione>> GetListeAsync(int idUtente, int tpXps,int ps, string? email, out int totalNum)
        {
            return _listaDistribuzioneRepository.GetListe(idUtente, tpXps,  ps, email, out totalNum);
        }

        public async Task<ListaDistribuzione> GetListaByNomeAsync(string nome)
        {
            return _listaDistribuzioneRepository.GetListaByNome(nome);
        }
    }
}
