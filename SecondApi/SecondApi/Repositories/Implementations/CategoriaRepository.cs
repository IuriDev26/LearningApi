using SecondApi.Context;
using SecondApi.Models;
using SecondApi.Repositories.Interfaces;

namespace SecondApi.Repositories.Implementations {
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository {

        public CategoriaRepository(ApiContext context) : base(context) 
        {
            
        }

    }
}
