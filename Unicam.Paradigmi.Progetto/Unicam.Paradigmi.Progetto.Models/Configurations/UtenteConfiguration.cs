using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Models.Configurations
{
    public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utenti");
            builder.HasKey(u => u.IdUtente);
            builder.Property(u => u.IdUtente).IsRequired();

        }
    }
}
