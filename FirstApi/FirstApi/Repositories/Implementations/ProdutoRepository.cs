using FirstApi.Context;
using FirstApi.Models;
using FirstApi.Repositories.Interfaces;

namespace FirstApi.Repositories.Implementations {
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository {

        public ProdutoRepository(ApiContext context) : base(context) 
        {
            
        }

        public IEnumerable<Produto> GetProdutos(ProdutosParameters parameters) {
            return GetAll().OrderBy( p => p.Descricao).Skip((parameters.PageNumber - 1)  * parameters.PageSize).Take(parameters.PageSize).ToList();
        }

        public IEnumerable<Produto> GetProdutosCategoria(int id) {
            return _context.Produtos.Where( p => p.CategoriaId == id).ToList();
        }
    }
}
