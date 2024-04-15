using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities.RelationshipEntities;

namespace Phoenix.Infrastructure.RelationshipEntitiesConfiguration;

public class FuncionarioAtividadeConfiguration : IEntityTypeConfiguration<FuncionarioAtividade>
{
    public void Configure(EntityTypeBuilder<FuncionarioAtividade> builder)
    {
        builder.HasKey(p => new { p.AtividadeId, p.FuncionarioId });


        builder.HasOne(p => p.Atividade)
            .WithMany(p => p.FuncionarioAtividades)
            .HasForeignKey(p => p.AtividadeId);

        builder.HasOne(p => p.Funcionario)
            .WithMany(p => p.FuncionarioAtividades)
            .HasForeignKey(p => p.FuncionarioId);
    }
}