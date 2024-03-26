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

        public PagedList<Categoria> FiltroCategoriaNome(CategoriasFiltroNome parameters) {

            var query = _context.Categorias.Where(c => c.Nome.Contains(parameters.Nome)).OrderBy(c => c.Nome).AsQueryable();

            return PagedList<Categoria>.ToPagedList(query, parameters.PageNumber, parameters.PageSize);


        }

        public PagedList<Categoria> GetCategorias(PaginationParameters parameters) {
            var query = _context.Categorias.OrderBy(c => c.Id).AsQueryable();
            return PagedList<Categoria>.ToPagedList(query, parameters.PageNumber, parameters.PageSize);


        }
    }
}
