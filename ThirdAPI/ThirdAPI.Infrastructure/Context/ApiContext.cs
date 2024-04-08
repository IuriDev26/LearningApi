using Microsoft.EntityFrameworkCore;
using ThirdAPI.Domain.Entities;


namespace ThirdAPI.Infrastructure.Context {
    public class ApiContext : DbContext {

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApiContext).Assembly);
        }


    }
}
