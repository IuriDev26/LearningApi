using SecondApi.Context;
using SecondApi.Repositories.Implementations;
using SecondApi.Repositories.Interfaces;

namespace SecondApi.UnitOfWork {
    public class UnitOfWork : IUnitOfWork {

        IProdutoRepository? produtoRepository;
        ICategoriaRepository? categoriaRepository;
        private readonly ApiContext _context;

        public UnitOfWork(ApiContext context) {
           _context = context;
            
        }


        public IProdutoRepository ProdutoRepository => produtoRepository =  produtoRepository ?? new ProdutoRepository(_context);

        public ICategoriaRepository CategoriaRepository => categoriaRepository = categoriaRepository ?? new CategoriaRepository(_context);

        public async Task CommitAsync() {
            await _context.SaveChangesAsync();
        }

        public async Task Dispose() {
            await _context.DisposeAsync();
        }
    }
}
