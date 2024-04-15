using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Infrastructure.EntitiesConfiguration {
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente> {
        public void Configure(EntityTypeBuilder<Cliente> builder) {

            builder.HasKey(x => x.Id);
            builder.Property( p => p.Cep ).HasMaxLength(8).IsFixedLength().IsRequired();
            builder.Property( p => p.CPF ).HasMaxLength(11).IsRequired();
            builder.Property( p => p.DataCadastro ).HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Property( p => p.Email ).HasMaxLength(50).IsRequired();
            builder.Property( p => p.Endereco).HasMaxLength(100).IsRequired();
            builder.Property( p => p.Telefone).HasMaxLength(9).IsRequired();
            builder.Property( p => p.ResidencialNumber);
            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();

            


        }
    }
}
