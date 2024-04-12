using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Infrastructure.EntitiesConfiguration {
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario> {
        public void Configure(EntityTypeBuilder<Funcionario> builder) {
            
            builder.HasKey(x => x.Id);
            builder.Property( p => p.Nome ).HasMaxLength(50).IsRequired();
            builder.Property( p => p.Idade ).IsRequired();
            builder.Property( p => p.Admissao ).HasDefaultValue( DateTime.UtcNow ).IsRequired();
            
                    



        }
    }
}
