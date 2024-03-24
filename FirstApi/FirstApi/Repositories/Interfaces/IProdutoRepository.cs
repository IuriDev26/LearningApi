using FirstApi.Models;

namespace FirstApi.Repositories.Interfaces {
    public interface IProdutoRepository : IRepository<Produto> {

        IEnumerable<Produto> GetProdutosCategoria(int id);

    }
}
