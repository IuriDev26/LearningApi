using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Infrastructure.EntitiesConfiguration {
    public class CompraConfiguration : IEntityTypeConfiguration<Compra> {
        public void Configure(EntityTypeBuilder<Compra> builder) {

            builder.HasKey(x => x.Id);
            builder.Property( p => p.Descricao ).HasMaxLength(100).IsRequired();
            builder.Property( p => p.FuncionarioId ).IsRequired();
            builder.Property( p => p.DataCompra ).HasDefaultValue( DateTime.UtcNow ).IsRequired();

            builder.HasOne(p => p.Funcionario).WithMany(p => p.Compras)
                .HasForeignKey(p => p.FuncionarioId);

        }
    }
}
