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
    public  class DestinatarioConfiguration : IEntityTypeConfiguration<Destinatario>
    {
        public void Configure(EntityTypeBuilder<Destinatario> builder)
        {
            builder.ToTable("Destinatari");
            builder.HasKey(u => u.IdDestinatario);


        }
    }
}
