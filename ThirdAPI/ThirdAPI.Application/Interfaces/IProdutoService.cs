using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdAPI.Application.DTOs;

namespace ThirdAPI.Application.Interfaces {
    public interface IProdutoService {

        Task<IEnumerable<ProdutoDTO>> GetAllAsync();
        Task<ProdutoDTO> GetByIdAsync(int id);
        Task<ProdutoDTO> Create(ProdutoDTO produtoDto);
        Task<ProdutoDTO> Update(ProdutoDTO produtoDto);
        Task<ProdutoDTO> Delete(int id);


    }
}
