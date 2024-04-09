using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThirdAPI.Application.DTOs;
using ThirdAPI.Application.Interfaces;

namespace ThirdAPI.API.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase {

        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService) {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoDTO>> GetAll() {

            return await _produtoService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ProdutoDTO> GetByIdAsync(int id) {

            return await _produtoService.GetByIdAsync(id);

        }


        [HttpPost]
        public async Task<ProdutoDTO> Create(ProdutoDTO produtoDto) {

            return await _produtoService.Create(produtoDto);

        }

        [HttpPut]
        public async Task<ProdutoDTO> Update(ProdutoDTO produtoDto) {

            return await _produtoService.Update(produtoDto);

        }

        [HttpDelete("{id:int}")]
        public async Task<ProdutoDTO> Delete(int id) {

            var produtoDto = await GetByIdAsync(id);

            return await _produtoService.Delete(produtoDto);

        }
    }
}
