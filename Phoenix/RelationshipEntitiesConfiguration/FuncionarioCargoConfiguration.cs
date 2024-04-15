using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities.RelationshipEntities;

namespace Phoenix.Infrastructure.RelationshipEntitiesConfiguration;

public class FuncionarioCargoConfiguration : IEntityTypeConfiguration<FuncionarioCargo>
{
    public void Configure(EntityTypeBuilder<FuncionarioCargo> builder)
    {
        builder.HasKey(p => new { p.FuncionarioId, p.CargoId });

        builder.HasOne(p => p.Funcionario)
            .WithMany(p => p.FuncionarioCargos)
            .HasForeignKey(p => p.FuncionarioId);

        builder.HasOne(p => p.Cargo)
            .WithMany(p => p.FuncionarioCargos)
            .HasForeignKey(p => p.Cargo);
    }
}