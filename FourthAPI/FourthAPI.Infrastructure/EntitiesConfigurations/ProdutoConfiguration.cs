using FourthAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthAPI.Infrastructure.EntitiesConfigurations {
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto> {
        public void Configure(EntityTypeBuilder<Produto> builder) {

            builder.HasKey(k => k.Id);
            builder.Property( p => p.Descricao).HasMaxLength(100).IsRequired();
            builder.Property( p => p.Preco ).HasDefaultValue(0).HasPrecision(10,2).IsRequired();
            builder.Property( p => p.Estoque).HasDefaultValue(0).IsRequired();
            builder.Property( p => p.DataCadastro).HasDefaultValue(DateTime.UtcNow).IsRequired();


            builder.HasOne( p => p.Categoria ).WithMany( c => c.Produtos ).HasForeignKey( c => c.CategoriaId );

            builder.HasData(
                new Produto("Mochila", 2, 20, 1),
                new Produto("Xiaomi Poco F3", 2250, 10, 2),
                new Produto("Capa para Celular", 10, 200, 3)
            );

        }
    }
}
