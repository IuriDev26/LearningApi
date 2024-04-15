using Phoenix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Interfaces {
    public interface IVendasRepository : IRepository<Venda> {

        Venda NewSale(Venda venda);
        Venda SaleCancel(Venda venda, string motivoCancel);
        Venda Replacement(Venda venda, List<int> produtosId);

    }
}
