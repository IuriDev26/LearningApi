using FourthAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthAPI.Application.Interfaces {
    public interface ICategoriaService {

        Task<IEnumerable<CategoriaDTO>> GetAllAsync();
        Task<CategoriaDTO> GetByIdAsync(int id);
        Task<CategoriaDTO> CreateAsync(CategoriaDTO categoriaDto);
        Task<CategoriaDTO> UpdateAsync(CategoriaDTO categoriaDto);
        Task<CategoriaDTO> DeleteAsync(int id);

    }
}
