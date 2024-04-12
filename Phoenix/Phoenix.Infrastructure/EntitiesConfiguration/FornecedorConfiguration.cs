using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Infrastructure.EntitiesConfiguration {
    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor> {
        public void Configure(EntityTypeBuilder<Fornecedor> builder) {

            builder.HasKey(x => x.Id);
            builder.Property( p => p.Nome ).HasMaxLength(50).IsRequired();
            builder.Property( p => p.CNPJ ).HasMaxLength(14).IsFixedLength().IsRequired();


            builder.HasMany(p => p.Produtos).WithOne(p => p.Fornecedor).HasForeignKey(p => p.FornecedorId);

        }
    }
}
