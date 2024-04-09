using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdAPI.Domain.Entities;

namespace ThirdAPI.Infrastructure.EntitiesConfigurations {
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria> {
        public void Configure(EntityTypeBuilder<Categoria> builder) {
            builder.HasKey( t => t.Id );
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ImagemUrl).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Categoria("Material Escolar", "material", 1),
                new Categoria("Eletônicos", "eletronicos.jpg", 2),
                new Categoria("Acessórios", "acessorios.jpg", 3)
                
                );

        }
    }
}
