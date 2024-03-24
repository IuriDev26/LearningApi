using FirstApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Context {
    public class ApiContext : DbContext {

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }
}
