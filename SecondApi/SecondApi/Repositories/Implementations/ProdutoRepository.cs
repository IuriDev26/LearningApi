using SecondApi.Context;
using SecondApi.Models;
using SecondApi.Repositories.Interfaces;

namespace SecondApi.Repositories.Implementations {
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository {

        public ProdutoRepository(ApiContext context) : base(context) 
        {
            
        }

    }
}
