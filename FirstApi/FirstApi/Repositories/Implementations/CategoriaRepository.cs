using FirstApi.Context;
using FirstApi.Models;
using FirstApi.Repositories.Interfaces;

namespace FirstApi.Repositories.Implementations {
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository {

        public CategoriaRepository(ApiContext context): base(context)
        {
            
        }

    }
}
