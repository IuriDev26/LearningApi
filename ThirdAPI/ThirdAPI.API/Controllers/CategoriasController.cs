using Microsoft.AspNetCore.Mvc;
using ThirdAPI.Application.DTOs;
using ThirdAPI.Application.Interfaces;

namespace ThirdAPI.API.Controllers {

    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase {

        private ICategoriaService _serviceCategoria;

        public CategoriasController(ICategoriaService serviceCategoria) {
            _serviceCategoria = serviceCategoria;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaDTO>> GetAllAsync() {

            return await _serviceCategoria.GetAllAsync();

        }


        [HttpGet("{id:int}")]
        public async Task<CategoriaDTO> GetById(int id) {

            return await _serviceCategoria.GetByIdAsync(id);

        }


        [HttpPost]
        public async Task<CategoriaDTO> Create(CategoriaDTO categoriaDto) {

            return await _serviceCategoria.Create(categoriaDto);

        }

        [HttpPut]
        public async Task<CategoriaDTO> Update(CategoriaDTO categoriaDto) {

            return await _serviceCategoria.Update(categoriaDto);

        }


        [HttpDelete]
        public async Task<CategoriaDTO> Delete(CategoriaDTO categoriaDto) {

            return await _serviceCategoria.Delete(categoriaDto);

        }
    }
}
