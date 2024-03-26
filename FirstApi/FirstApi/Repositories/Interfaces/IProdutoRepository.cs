using FirstApi.Filtros;
using FirstApi.Models;
using FirstApi.Pagination;

namespace FirstApi.Repositories.Interfaces {
    public interface IProdutoRepository : IRepository<Produto> {

        IEnumerable<Produto> GetProdutosCategoria(int id);

        IEnumerable<Produto> GetProdutosx(PaginationParameters parameters);

        PagedList<Produto> GetProdutos(PaginationParameters parameters);

        PagedList<Produto> FiltroByPreco(ProdutosFiltroPreco parameters);


    }
}
