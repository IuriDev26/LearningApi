using FirstApi.Context;
using FirstApi.Filtros;
using FirstApi.Models;
using FirstApi.Pagination;
using FirstApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Repositories.Implementations {
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository {

        public ProdutoRepository(ApiContext context) : base(context) 
        {
            
        }

        public async Task<IEnumerable<Produto>> GetProdutosxAsync(PaginationParameters parameters) {
            return await _context.Produtos.OrderBy( p => p.Descricao).Skip((parameters.PageNumber - 1)  * parameters.PageSize).Take(parameters.PageSize).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetProdutosCategoriaAsync(int id) {
            return await _context.Produtos.Where( p => p.CategoriaId == id).ToListAsync();
        }

        public async Task<PagedList<Produto>> GetProdutosAsync(PaginationParameters parameters) {
            var query = _context.Produtos.OrderBy(p => p.Id).AsQueryable();
            return await PagedList<Produto>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<Produto>> FiltroByPrecoAsync(ProdutosFiltroPreco parameters) {

            IQueryable<Produto> query;
           
            if (parameters.Criterio.ToLower() == "igual") {

                query = _context.Produtos.Where( p => p.Preco == parameters.Preco ).OrderBy( p => p.Preco ).AsQueryable();
                
            } else if (parameters.Criterio.ToLower() == "menor"){
                query = _context.Produtos.Where( p => p.Preco <  parameters.Preco ).OrderBy( p => p.Preco ).AsQueryable();
            } else {
                query = _context.Produtos.Where( p => p.Preco >  parameters.Preco ).OrderBy( p => p.Preco) .AsQueryable();
            }

            return await PagedList<Produto>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);

            
        }
    }
}
