using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondApi.Models;

namespace SecondApi.Context {
    public class ApiContext : IdentityDbContext<ApplicationUser> {

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) 
        {
            
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
        }

    }
}
