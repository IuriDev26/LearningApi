using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities.RelationshipEntities;

namespace Phoenix.Infrastructure.RelationshipEntitiesConfiguration;

public class CompraProdutoConfiguration : IEntityTypeConfiguration<CompraProduto>
{
    public void Configure(EntityTypeBuilder<CompraProduto> builder)
    {
        builder.HasKey(p => new { p.CompraId, p.ProdutoId });

        builder.HasOne(p => p.Compra)
            .WithMany(p => p.CompraProdutos)
            .HasForeignKey(p => p.CompraId);

        builder.HasOne(p => p.Produto)
            .WithMany(p => p.CompraProdutos)
            .HasForeignKey(p => p.Produto);
    }
}