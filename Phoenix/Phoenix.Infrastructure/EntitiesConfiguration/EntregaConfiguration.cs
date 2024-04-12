using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities;
using Phoenix.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Infrastructure.EntitiesConfiguration {
    public class EntregaConfiguration : IEntityTypeConfiguration<Entrega> {
        public void Configure(EntityTypeBuilder<Entrega> builder) {

            builder.HasKey(x => x.Id);
            builder.Property( p => p.VendaId ).IsRequired();
            builder.Property( p => p.DataVenda ).IsRequired();
            builder.Property( p => p.DataEntrega).HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Property( p => p.StatusEntrega ).HasDefaultValue(StatusEntregaEnum.AwaitingRoute).IsRequired();


            builder.HasOne( p => p.Venda).WithOne().HasForeignKey<Entrega>(p => p.VendaId);
            builder.HasOne( p => p.RotaEntrega).WithMany( p => p.Entregas ).HasForeignKey(p => p.RotaEntregaId);

        }
    }
}
