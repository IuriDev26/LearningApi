using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities.RelationshipEntities;

namespace Phoenix.Infrastructure.RelationshipEntitiesConfiguration;

public class CargoAtividadeConfiguration : IEntityTypeConfiguration<CargoAtividade>
{
    public void Configure(EntityTypeBuilder<CargoAtividade> builder)
    {
        builder.HasKey(p => new { p.CargoId, p.AtividadeId });

        builder.HasOne(p => p.Cargo)
            .WithMany(p => p.CargoAtividades)
            .HasForeignKey(p => p.CargoId);

        builder.HasOne(p => p.Atividade)
            .WithMany(p => p.CargoAtividades)
            .HasForeignKey(p => p.AtividadeId);


    }
}