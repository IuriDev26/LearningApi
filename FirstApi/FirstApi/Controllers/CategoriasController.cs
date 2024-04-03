using AutoMapper;
using FirstApi.DTOs.Entities;
using FirstApi.Filters;
using FirstApi.Filtros;
using FirstApi.Models;
using FirstApi.Pagination;
using FirstApi.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FirstApi.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase {

        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public CategoriasController(IUnitOfWork uof, IMapper mapper) {
            _uof = uof;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get() => Ok(_mapper.Map<IEnumerable<CategoriaDTO>>(await _uof.CategoriaRepository.GetAllAsync()));

        [HttpGet("{id:int}", Name ="ObterCategoria")]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public async Task<ActionResult<CategoriaDTO>> GetById(int id) {
            return Ok(_mapper.Map<CategoriaDTO>(await _uof.CategoriaRepository.GetByIdAsync(c => c.Id == id )));
        }

        [HttpGet("Pagination")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias([FromQuery] PaginationParameters parameters) {

            var categorias = await _uof.CategoriaRepository.GetCategoriasAsync(parameters);

            return ObterCategoriaPagination(categorias);
        }

        [HttpGet("Nome")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> FilterByName([FromQuery] CategoriasFiltroNome parameters) {

            var categorias = await _uof.CategoriaRepository.FiltroCategoriaNomeAsync(parameters);

            return ObterCategoriaPagination(categorias);

        }


        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> Post(CategoriaDTO categoriaDto) {

            var categoria = _mapper.Map<Categoria>(categoriaDto);
            var categoriaAlterada = _mapper.Map<CategoriaDTO>(_uof.CategoriaRepository.Create(categoria));
            await _uof.CommitAsync();
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoriaAlterada.Id }, categoriaAlterada);
        }

        [HttpPut]
        public async Task<ActionResult<CategoriaDTO>> Put(CategoriaDTO categoriaDto) {

            var categoria = _mapper.Map<Categoria>(categoriaDto);
            var categoriaAlterada = _mapper.Map<CategoriaDTO>(_uof.CategoriaRepository.Update(categoria));
            await _uof.CommitAsync();
            return Ok(categoriaAlterada);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id) {

            var categoria = await _uof.CategoriaRepository.GetByIdAsync(c => c.Id == id);
            var deletedCategoria = _mapper.Map<CategoriaDTO>(_uof.CategoriaRepository.Delete(categoria));
            await _uof.CommitAsync();
            return Ok(deletedCategoria);
        }

        private ActionResult<IEnumerable<CategoriaDTO>> ObterCategoriaPagination(PagedList<Categoria> categorias) {

            var metadata = new {
                categorias.PageSize,
                categorias.TotalCount,
                categorias.CurrentPage,
                categorias.TotalPages,
                categorias.HasNext,
                categorias.HasPrevious
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

            var categoriasDto = _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
            return Ok(categoriasDto);

        }

    }
}
