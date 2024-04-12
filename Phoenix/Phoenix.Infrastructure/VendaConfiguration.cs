using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities;
using Phoenix.Domain.Entities.Enums;

namespace Phoenix.Infrastructure;

public class VendaConfiguration : IEntityTypeConfiguration<Venda>
{
    public void Configure(EntityTypeBuilder<Venda> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Status)
            .HasDefaultValue(StatusVendaEnum.Finalizada)
            .IsRequired();
        builder.Property(p => p.DataVenda).HasDefaultValue(DateTime.UtcNow)
            .IsRequired();
        builder.Property(p => p.ClienteId).IsRequired();

        builder.HasOne(p => p.Cliente)
            .WithMany(p => p.Compras)
            .HasForeignKey(p => p.ClienteId);
        
        


    }
}