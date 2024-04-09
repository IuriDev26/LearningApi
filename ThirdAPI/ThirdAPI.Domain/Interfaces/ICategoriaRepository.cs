using ThirdAPI.Domain.Entities;

namespace ThirdAPI.Domain.Interfaces {
    public interface ICategoriaRepository {


        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<Categoria> GetByIdAsync(int id);
        Task<Categoria> Create(Categoria categoria);
        Task<Categoria> Update(Categoria categoria);
        Task<Categoria> Delete(Categoria categoria); 


    }
}
