using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThirdAPI.Domain.Entities;

namespace ThirdAPI.Infrastructure.EntitiesConfigurations {
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto> {
        public void Configure(EntityTypeBuilder<Produto> builder) {

            builder.HasKey( k => k.Id);
            builder.Property( p => p.Nome ).HasMaxLength(100).IsRequired();
            builder.Property( p => p.Descricao ).HasMaxLength(100).IsRequired();
            builder.Property( p => p.DataCadastro).HasDefaultValue(DateTime.UtcNow);
            builder.Property( p => p.Preco ).HasPrecision(10).IsRequired();
            builder.Property( p => p.Estoque ).HasDefaultValue(1).IsRequired();

            builder.HasOne(p => p.Categoria).WithMany(e => e.Produtos).HasForeignKey(e => e.CategoriaId);

        }
    }
}
