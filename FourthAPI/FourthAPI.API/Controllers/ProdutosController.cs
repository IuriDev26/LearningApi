using FourthAPI.Application.DTOs;
using FourthAPI.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourthAPI.API.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase {

        private IProdutoService _service;

        public ProdutosController(IProdutoService service) {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoDTO>> GetAllAsync() {

            return await _service.GetAllAsync();

        }

        [HttpGet("{id:int}")]
        public async Task<ProdutoDTO> GetByIdAsync(int id) {

            return await _service.GetByIdAsync(id);

        }


        [HttpPost]
        public async Task<ProdutoDTO> Create(ProdutoDTO produtoDto) {

            return await _service.CreateAsync(produtoDto);

        }


        [HttpPut]
        public async Task<ProdutoDTO> Update(ProdutoDTO produtoDto) {

            return await _service.UpdateAsync(produtoDto);

        }


        [HttpDelete("{id:int}")]
        public async Task<ProdutoDTO> Delete(int id) {

            return await _service.DeleteAsync(id);
        }

    }
}
