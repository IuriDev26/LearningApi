using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Infrastructure.EntitiesConfiguration
{
    public class DevolucaoVendaConfiguration : IEntityTypeConfiguration<DevolucaoVenda> {
        public void Configure(EntityTypeBuilder<DevolucaoVenda> builder) {
            
            builder.HasKey(x => x.Id);
            builder.Property( p => p.Motivo ).HasMaxLength(200).IsRequired();
            builder.Property( p => p.DataDevolucao ).HasDefaultValue(DateTime.UtcNow).IsRequired();

            builder.HasOne(p => p.VendaDevolvida).WithOne().HasForeignKey<DevolucaoVenda>( p => p.VendaId );

        }
    }
}
