using FourthAPI.Application.DTOs;
using FourthAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FourthAPI.API.Controllers {


    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase {

        private readonly ICategoriaService _service;

        public CategoriasController(ICategoriaService service) {
            _service = service;
        }


        [HttpGet]
        public async Task<IEnumerable<CategoriaDTO>> GetAllAsync() {

            return await _service.GetAllAsync();

        }


        [HttpGet("{id:int}")]
        public async Task<CategoriaDTO> GetByIdAsync(int id) {

            return await _service.GetByIdAsync(id);

        }


        [HttpPost]
        public async Task<CategoriaDTO> Create(CategoriaDTO categoriaDto) {

            return await _service.CreateAsync(categoriaDto);

        }


        [HttpPut]
        public async Task<CategoriaDTO> UpdateAsync(CategoriaDTO categoriaDto) {

            return await _service.UpdateAsync(categoriaDto);

        }


        [HttpDelete("{id:int}")]
        public async Task<CategoriaDTO> DeleteByIdAsync(int id) {

            return await _service.DeleteAsync(id);

        }
        

    }
}
