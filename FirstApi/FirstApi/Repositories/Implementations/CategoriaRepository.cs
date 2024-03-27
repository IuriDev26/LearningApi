using FirstApi.Context;
using FirstApi.Filtros;
using FirstApi.Models;
using FirstApi.Pagination;
using FirstApi.Repositories.Interfaces;

namespace FirstApi.Repositories.Implementations {
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository {

        public CategoriaRepository(ApiContext context): base(context)
        {
            
        }

        public async Task<PagedList<Categoria>> FiltroCategoriaNomeAsync(CategoriasFiltroNome parameters) {

            var query = _context.Categorias.Where(c => c.Nome.Contains(parameters.Nome)).OrderBy(c => c.Nome).AsQueryable();

            return await PagedList<Categoria>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);


        }

        public async Task<PagedList<Categoria>> GetCategoriasAsync(PaginationParameters parameters) {
            var query = _context.Categorias.OrderBy(c => c.Id).AsQueryable();
            return await PagedList<Categoria>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);


        }
    }
}
