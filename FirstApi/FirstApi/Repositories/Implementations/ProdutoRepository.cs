using FirstApi.Context;
using FirstApi.Models;
using FirstApi.Repositories.Interfaces;

namespace FirstApi.Repositories.Implementations {
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository {

        public ProdutoRepository(ApiContext context) : base(context) 
        {
            
        }

        public IEnumerable<Produto> GetProdutosCategoria(int id) {
            return _context.Produtos.Where( p => p.CategoriaId == id).ToList();
        }
    }
}
