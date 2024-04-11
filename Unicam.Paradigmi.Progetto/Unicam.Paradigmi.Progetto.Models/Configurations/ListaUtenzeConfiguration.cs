using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Progetto.Models.Entities;

namespace Unicam.Paradigmi.Progetto.Models.Configurations
{
    public class ListaUtenzeConfiguration : IEntityTypeConfiguration<ListaUtenze>
    {
        public void Configure(EntityTypeBuilder<ListaUtenze> builder)
        {
            builder.ToTable("ListeUtenze");
            builder.HasKey(u => u.Nome);
            builder.Property(u => u.Nome).IsRequired();
            builder.HasOne(x => x.Proprietario)
                .WithMany(x => x.ListaUtenze)
                .HasForeignKey(x => x.EmailProprietario);
        }
    }
}