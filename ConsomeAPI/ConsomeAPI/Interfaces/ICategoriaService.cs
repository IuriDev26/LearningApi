using ConsomeAPI.Models;

namespace ConsomeAPI.Interfaces {
    public interface ICategoriaService {

        Task<IEnumerable<CategoriaViewModel>> GetCategorias();
        Task<CategoriaViewModel> GetCategoriaById(int id);
        Task<CategoriaViewModel> CriaCategoria(CategoriaViewModel categoriaVM);
        Task<bool> AtualizaCategoria(int id, CategoriaViewModel categoriaVM);
        Task<bool> DeletaCategoria(int id);


    }
}
