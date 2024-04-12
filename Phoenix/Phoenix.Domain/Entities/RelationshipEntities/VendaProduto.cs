using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities.RelationshipEntities
{
    public class VendaProduto
    {

        public int ProdutoId { get; private set; }
        public int VendaId { get; private set; }
        public Venda? Venda { get; private set; }
        public Produto? Produto { get; private set; }

        public VendaProduto(Venda? venda, Produto? produto)
        {

            ValidateDomain(venda, produto);
        }

        private void ValidateDomain(Venda? venda, Produto? produto)
        {

            Venda = venda;
            Produto = produto;

        }

    }
}
