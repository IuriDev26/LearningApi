using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdAPI.Application.DTOs;

namespace ThirdAPI.Application.Interfaces {
    public interface ICategoriaService {

        Task<IEnumerable<CategoriaDTO>> GetAllAsync();
        Task<CategoriaDTO> GetByIdAsync(int id);
        Task<CategoriaDTO> Create(CategoriaDTO categoriaDTO);
        Task<CategoriaDTO> Update(CategoriaDTO categoriaDTO);
        Task<CategoriaDTO> Delete(CategoriaDTO categoriaDTO);


    }
}
