using FirstApi.Context;
using FirstApi.Filtros;
using FirstApi.Models;
using FirstApi.Pagination;
using FirstApi.Repositories.Interfaces;

namespace FirstApi.Repositories.Implementations {
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository {

        public ProdutoRepository(ApiContext context) : base(context) 
        {
            
        }

        public IEnumerable<Produto> GetProdutosx(PaginationParameters parameters) {
            return GetAll().OrderBy( p => p.Descricao).Skip((parameters.PageNumber - 1)  * parameters.PageSize).Take(parameters.PageSize).ToList();
        }

        public IEnumerable<Produto> GetProdutosCategoria(int id) {
            return _context.Produtos.Where( p => p.CategoriaId == id).ToList();
        }

        public PagedList<Produto> GetProdutos(PaginationParameters parameters) {
            var query = _context.Produtos.OrderBy(p => p.Id).AsQueryable();
            return PagedList<Produto>.ToPagedList(query, parameters.PageNumber, parameters.PageSize);
        }

        public PagedList<Produto> FiltroByPreco(ProdutosFiltroPreco parameters) {

            IQueryable<Produto> query;
           
            if (parameters.Criterio.ToLower() == "igual") {

                query = _context.Produtos.Where( p => p.Preco == parameters.Preco ).OrderBy( p => p.Preco ).AsQueryable();
                
            } else if (parameters.Criterio.ToLower() == "menor"){
                query = _context.Produtos.Where(p => p.Preco < parameters.Preco).OrderBy(p => p.Preco).AsQueryable();
            } else {
                query = _context.Produtos.Where(p => p.Preco > parameters.Preco).OrderBy(p => p.Preco).AsQueryable();
            }

            return PagedList<Produto>.ToPagedList(query, parameters.PageNumber, parameters.PageSize);

            
        }
    }
}
