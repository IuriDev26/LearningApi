using SecondApi.Repositories.Interfaces;

namespace SecondApi.UnitOfWork {
    public interface IUnitOfWork {

        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }

        Task CommitAsync();
        Task Dispose();



    }
}
