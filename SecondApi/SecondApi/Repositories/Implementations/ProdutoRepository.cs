using SecondApi.Context;
using SecondApi.Models;
using SecondApi.Repositories.Interfaces;

namespace SecondApi.Repositories.Implementations {
    public class ProdutoRepository<Produto> : Repository<Produto>, IRepository<Produto>  {

        private readonly ApiContext _context;

        public ProdutoRepository(ApiContext context) : base(context) 
        {
            _context = context;
        }


    }
}
