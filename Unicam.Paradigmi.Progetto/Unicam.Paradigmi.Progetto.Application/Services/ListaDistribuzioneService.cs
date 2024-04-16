using Unicam.Paradigmi.Progetto.Models.Entities;
using Unicam.Paradigmi.Progetto.Models.Repositories;

namespace Unicam.Paradigmi.Progetto.Application.Services
{
    public class ListaDistribuzioneService
    {
        private readonly ListaDistribuzioneRepository _utenzaRepository;
        public ListaDistribuzioneService(ListaDistribuzioneRepository utenzaRepository)
        {
            _utenzaRepository = utenzaRepository;
        }
        public void AddLista(ListaDistribuzione lista)
        {
            _utenzaRepository.Aggiungi(lista);
            _utenzaRepository.Save();
        }
        public int GetidProprietario(int idListaDistribuzione)
        {
            return _utenzaRepository.GetIdFromLista(idListaDistribuzione);
        }
    }
}
