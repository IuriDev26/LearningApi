using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Infrastructure.EntitiesConfiguration {
    public class AtividadeConfiguration : IEntityTypeConfiguration<Atividade> {
        public void Configure(EntityTypeBuilder<Atividade> builder) {
            
            builder.HasKey( x => x.Id);
            builder.Property( p => p.Descricao ).HasMaxLength(100).IsRequired();
            builder.Property( p => p.Nome ).HasMaxLength(30).IsRequired();

        }
    }
}
