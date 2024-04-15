]using Microsoft.EntityFrameworkCore;
using Phoenix.Domain.Entities;
using Phoenix.Domain.Interfaces;
using Phoenix.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Infrastructure.Repositories {
    public class VendasRepository : Repository<Venda>, IVendasRepository {
        public VendasRepository(ApiContext context) : base(context) {
        }

        public Venda NewSale(Venda venda) {
            
            _context.Vendas.Add(venda);
            return venda;

        }

        public Venda Replacement(Venda venda, List<int> produtosId) {
            
            foreach (var produto in venda.Produtos) {

                if ( produtosId.Contains(produto.Id) ) {

                    venda.Produtos.Remove(produto);

                }

            }

            _context.Vendas.Update(venda);
            return venda;

        }

        public Venda SaleCancel(Venda venda, string motivoCancel) {

            venda.SaleCancel();
            var vendaDevolvida = new DevolucaoVenda(motivoCancel, DateTime.UtcNow,venda);

            _context.Vendas.Update(venda);
            _context.DevolucaoVendas.Add(vendaDevolvida);

            return venda;
        }
    }
}
