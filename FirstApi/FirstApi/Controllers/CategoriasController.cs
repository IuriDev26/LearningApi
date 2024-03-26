using AutoMapper;
using FirstApi.DTOs.Entities;
using FirstApi.Filters;
using FirstApi.Models;
using FirstApi.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<CategoriaDTO>> Get() => Ok(_mapper.Map<IEnumerable<CategoriaDTO>>(_uof.CategoriaRepository.GetAll()));

        [HttpGet("{id:int}", Name ="ObterCategoria")]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<CategoriaDTO> GetById(int id) {
            return Ok(_mapper.Map<CategoriaDTO>(_uof.CategoriaRepository.GetById(c => c.Id == id )));
        }


        [HttpPost]
        public ActionResult<CategoriaDTO> Post(CategoriaDTO categoriaDto) {

            var categoria = _mapper.Map<Categoria>(categoriaDto);
            var categoriaAlterada = _mapper.Map<CategoriaDTO>(_uof.CategoriaRepository.Create(categoria));
            _uof.Commit();
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoriaAlterada.Id }, categoriaAlterada);
        }

        [HttpPut]
        public ActionResult<CategoriaDTO> Put(CategoriaDTO categoriaDto) {

            var categoria = _mapper.Map<Categoria>(categoriaDto);
            var categoriaAlterada = _mapper.Map<CategoriaDTO>(_uof.CategoriaRepository.Update(categoria));
            _uof.Commit();
            return Ok(categoriaAlterada);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<CategoriaDTO> Delete(int id) {

            var categoria = _uof.CategoriaRepository.GetById(c => c.Id == id);
            var deletedCategoria = _mapper.Map<CategoriaDTO>(_uof.CategoriaRepository.Delete(categoria));
            _uof.Commit();
            return Ok(deletedCategoria);
        }

    }
}
