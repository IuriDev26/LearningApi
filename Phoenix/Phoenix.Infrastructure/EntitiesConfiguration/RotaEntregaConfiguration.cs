using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities;
using Phoenix.Domain.Entities.Enums;

namespace Phoenix.Infrastructure.EntitiesConfiguration;

public class RotaEntregaConfiguration : IEntityTypeConfiguration<RotaEntrega>
{
    public void Configure(EntityTypeBuilder<RotaEntrega> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.Status).HasDefaultValue(StatusRotaEnum.Created)
            .IsRequired();
        
        
        
        
    }
}