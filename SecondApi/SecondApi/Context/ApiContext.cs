using Microsoft.EntityFrameworkCore;
using SecondApi.Models;

namespace SecondApi.Context {
    public class ApiContext : DbContext {

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) 
        {
            
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }


    }
}
