using FirstApi.Repositories.Interfaces;

namespace FirstApi.UnitOfWork {
    public interface IUnitOfWork {

        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        Task CommitAsync();

    }
}
