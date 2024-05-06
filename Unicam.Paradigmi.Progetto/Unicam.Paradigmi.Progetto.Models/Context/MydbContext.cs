using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Models.Context
{
    public class MydbContext : DbContext
    {
        public MydbContext(DbContextOptions<MydbContext> options) : base(options)
        {

        }
        public DbSet<ListaDistribuzione> ListeDistribuzioni { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<ListaUtenzeAssociate> ListaUtenzeAssociate { get; set; }
        public DbSet<Destinatario> Destinatari { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
