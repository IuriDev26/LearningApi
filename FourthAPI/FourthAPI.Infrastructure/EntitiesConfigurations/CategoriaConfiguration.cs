using FourthAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthAPI.Infrastructure.EntitiesConfigurations {
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria> {
        public void Configure(EntityTypeBuilder<Categoria> builder) {
            
            builder.HasKey( k => k.Id );
            builder.Property( p => p.Nome ).HasMaxLength(100).IsRequired();


            builder.HasData(
                new Categoria("Material Escolar"), 
                new Categoria("Eletrônicos"),
                new Categoria("Acessórios")                   
            );

        }
    }
}
