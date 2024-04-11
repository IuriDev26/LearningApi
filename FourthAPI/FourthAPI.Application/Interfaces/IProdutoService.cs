using FourthAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthAPI.Application.Interfaces {
    public interface IProdutoService {

        Task<IEnumerable<ProdutoDTO>> GetAllAsync();
        Task<ProdutoDTO> GetByIdAsync(int id);
        Task<ProdutoDTO> CreateAsync(ProdutoDTO produtoDTO);
        Task<ProdutoDTO> UpdateAsync(ProdutoDTO produtoDTO);
        Task<ProdutoDTO> DeleteAsync(int id);

    }
}
