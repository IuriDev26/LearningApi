using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdAPI.Domain.Entities;

namespace ThirdAPI.Infrastructure.EntitiesConfigurations {
    public class CategoriaConfigurantion : IEntityTypeConfiguration<Categoria> {
        public void Configure(EntityTypeBuilder<Categoria> builder) {
            builder.HasKey( t => t.Id );
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ImagemUrl).HasMaxLength(100).IsRequired();

        }
    }
}
