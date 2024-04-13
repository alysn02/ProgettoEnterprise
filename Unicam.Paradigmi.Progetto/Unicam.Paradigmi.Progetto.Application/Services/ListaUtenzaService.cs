using Unicam.Paradigmi.Progetto.Models.Entities;
using Unicam.Paradigmi.Progetto.Models.Repositories;

namespace Unicam.Paradigmi.Progetto.Application.Services
{
    public class ListaUtenzaService
    {
        private readonly ListaUtenzaRepository _utenzaRepository;
        public ListaUtenzaService(ListaUtenzaRepository utenzaRepository)
        {
            _utenzaRepository = utenzaRepository;
        }
        public void AddLista(ListaDistribuzione lista)
        {
            _utenzaRepository.Aggiungi(lista);
            _utenzaRepository.Save();
        }
    }
}
