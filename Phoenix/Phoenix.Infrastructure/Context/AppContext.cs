using Microsoft.EntityFrameworkCore;
using Phoenix.Domain.Entities;
using Phoenix.Domain.Entities.RelationshipEntities;
using Phoenix.Infrastructure.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Infrastructure.Context
{
    public class AppContext : DbContext {
        public AppContext(DbContextOptions options) : base(options) {
        
        
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<CargoAtividade> CargoAtividade { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraProduto> CompraProduto { get; set; }
        public DbSet<DevolucaoVendaConfiguration> DevolucaoVendas { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<RotaEntrega> RotasEntrega { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaProduto> VendasProduto { get; set; }


        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);

        }






    }
}
