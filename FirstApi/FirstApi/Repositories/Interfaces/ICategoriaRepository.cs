using FirstApi.Filtros;
using FirstApi.Models;
using FirstApi.Pagination;

namespace FirstApi.Repositories.Interfaces {
    public interface ICategoriaRepository : IRepository<Categoria> {

        PagedList<Categoria> GetCategorias(PaginationParameters parameters);

        PagedList<Categoria> FiltroCategoriaNome(CategoriasFiltroNome parameters);


    }
}
