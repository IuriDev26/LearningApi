using FirstApi.Context;
using FirstApi.Repositories.Implementations;
using FirstApi.Repositories.Interfaces;

namespace FirstApi.UnitOfWork {
    public class UnitOfWork : IUnitOfWork {

        IProdutoRepository? _produtoRepository;
        ICategoriaRepository? _categoriaRepository;
        readonly ApiContext _context;

        public UnitOfWork(ApiContext context)
        {
            _context = context;
        }

        public IProdutoRepository ProdutoRepository => _produtoRepository = _produtoRepository ?? new ProdutoRepository(_context);

        public ICategoriaRepository CategoriaRepository => _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_context);  

        public void Commit() {
            _context.SaveChanges();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
