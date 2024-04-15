using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities.RelationshipEntities;

namespace Phoenix.Infrastructure.RelationshipEntitiesConfiguration;

public class VendaProdutoConfiguration : IEntityTypeConfiguration<VendaProduto>
{
    public void Configure(EntityTypeBuilder<VendaProduto> builder)
    {
        builder.HasKey(p => new { p.ProdutoId, p.VendaId });

        builder.HasOne(p => p.Produto)
            .WithMany(p => p.VendaProdutos)
            .HasForeignKey(p => p.ProdutoId);

        builder.HasOne(p => p.Venda)
            .WithMany(p => p.VendaProdutos)
            .HasForeignKey(p => p.VendaId);
    }
}