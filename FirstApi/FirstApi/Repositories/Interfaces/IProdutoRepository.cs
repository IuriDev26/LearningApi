using FirstApi.Filtros;
using FirstApi.Models;
using FirstApi.Pagination;

namespace FirstApi.Repositories.Interfaces {
    public interface IProdutoRepository : IRepository<Produto> {

        Task<IEnumerable<Produto>> GetProdutosCategoriaAsync(int id);

        Task<IEnumerable<Produto>> GetProdutosxAsync(PaginationParameters parameters);

        Task<PagedList<Produto>> GetProdutosAsync(PaginationParameters parameters);

        Task<PagedList<Produto>> FiltroByPrecoAsync(ProdutosFiltroPreco parameters);


    }
}
