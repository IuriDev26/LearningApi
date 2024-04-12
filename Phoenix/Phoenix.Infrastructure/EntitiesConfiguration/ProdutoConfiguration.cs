using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities;

namespace Phoenix.Infrastructure.EntitiesConfiguration;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.Descricao).HasMaxLength(100).IsRequired();
        builder.Property(p => p.PrecoVenda).IsRequired();
        builder.Property(p => p.PrecoCompra).IsRequired();
        builder.Property(p => p.Estoque).IsRequired();
        builder.Property(p => p.FornecedorId).IsRequired();
        builder.Property(p => p.DataCadastro).HasDefaultValue(DateTime.UtcNow).IsRequired();
        
    }
}