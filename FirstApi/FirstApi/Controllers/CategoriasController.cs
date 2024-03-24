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

        public CategoriasController(IUnitOfWork uof) {
            _uof = uof;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get() => Ok(_uof.CategoriaRepository.GetAll());

        [HttpGet("{id:int}", Name ="ObterCategoria")]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<Categoria> GetById(int id) {
            return Ok(_uof.CategoriaRepository.GetById(c => c.Id == id ));
        }


        [HttpPost]
        public ActionResult<Categoria> Post(Categoria categoria) {
            var categoriaAlterada = _uof.CategoriaRepository.Create(categoria);
            _uof.Commit();
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoriaAlterada.Id }, categoriaAlterada);
        }

        [HttpPut]
        public ActionResult<Categoria> Put(Categoria categoria) {
            var categoriaAlterada = _uof.CategoriaRepository.Update(categoria);
            _uof.Commit();
            return Ok(categoriaAlterada);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> Delete(int id) {

            var categoria = _uof.CategoriaRepository.GetById(c => c.Id == id);
            var deletedCategoria = _uof.CategoriaRepository.Delete(categoria);
            _uof.Commit();
            return Ok(deletedCategoria);
        }

    }
}
