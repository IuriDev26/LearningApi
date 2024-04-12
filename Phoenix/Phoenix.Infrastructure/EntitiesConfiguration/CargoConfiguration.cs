using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Infrastructure.EntitiesConfiguration {
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo> {
        public void Configure(EntityTypeBuilder<Cargo> builder) {

            builder.HasKey(x => x.Id);
            builder.Property( p => p.Descricao ).HasMaxLength(100).IsRequired();
            builder.Property( p => p.Nome ).HasMaxLength(50).IsRequired();


        }
    }
}
