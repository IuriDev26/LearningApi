using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Domain.Entities.RelationshipEntities
{
    public class CompraProduto
    {

        public Compra Compra { get; private set; }
        public Produto Produto { get; private set; }
        public int CompraId { get; private set; }
        public int ProdutoId { get; private set; }

        public CompraProduto(Compra compra, Produto produto)
        {
            Compra = compra;
            Produto = produto;
        }
    }
}
