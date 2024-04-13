using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Progetto.Models.Context;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Models.Repositories
{
    public class ListaUtenzaRepository
    {
        protected MydbContext _ctx;
        public ListaUtenzaRepository(MydbContext ctx)
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
    }
}
