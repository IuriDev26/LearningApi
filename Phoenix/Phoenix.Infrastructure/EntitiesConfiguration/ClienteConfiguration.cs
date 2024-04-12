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
            builder.Property( p => p.CPF ).HasMaxLength(8).IsRequired();
            builder.Property( p => p.DataCadastro ).HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Property( p => p.Email ).IsRequired();
            builder.Property( p => p.Endereco).IsRequired();
            builder.Property( p => p.Telefone);
            builder.Property( p => p.ResidencialNumber);

            


        }
    }
}
