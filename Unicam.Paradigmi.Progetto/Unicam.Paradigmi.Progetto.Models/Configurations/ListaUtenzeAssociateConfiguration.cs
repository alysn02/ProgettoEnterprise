using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Models.Configurations
{
    public class ListaUtenzeAssociateConfiguration : IEntityTypeConfiguration<ListaUtenzeAssociate>
    {
        public void Configure(EntityTypeBuilder<ListaUtenzeAssociate> builder)
        {
            builder.ToTable("ListeUtenzeAssociate");
            builder.HasKey(u => u.IdListaAssociata);

            //relazione con destinatario
            builder.HasOne(u => u.Destinatario)
                .WithMany(u => u.ListaUtenzeAssociate)
                .HasForeignKey(u => u.IdDestinatario);

            //relazione con lista distribuzione
            builder.HasOne(u => u.Lista)
                .WithMany(u => u.EmailDestinatarie)
                .HasForeignKey(u => u.IdListaDistribuzione);
        }
    }
}
