using FirstApi.Filtros;
using FirstApi.Models;
using FirstApi.Pagination;

namespace FirstApi.Repositories.Interfaces {
    public interface ICategoriaRepository : IRepository<Categoria> {

        Task<PagedList<Categoria>> GetCategoriasAsync(PaginationParameters parameters);

        Task<PagedList<Categoria>> FiltroCategoriaNomeAsync(CategoriasFiltroNome parameters);


    }
}
