using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Progetto.Models.Context;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Models.Repositories
{
    public class ListaDistribuzioneRepository
    {
        protected MydbContext _ctx;
        public ListaDistribuzioneRepository(MydbContext ctx)
        {
            _ctx = ctx;
        }
        public void Aggiungi(ListaDistribuzione lista)
        {
            _ctx.Set<ListaDistribuzione>().Add(lista);
            //non traccio i figli 
            //_ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
        public int GetIdFromLista(int idListaDistribuzione)
        {
            var lista = _ctx.ListeDistribuzioni.First(x => x.IdLista == idListaDistribuzione);
            return lista.IdProprietario;
        }

    }
}
