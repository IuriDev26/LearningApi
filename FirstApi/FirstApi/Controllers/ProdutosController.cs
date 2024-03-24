using FirstApi.Models;
using FirstApi.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase {

        private readonly IUnitOfWork _uof;

        public ProdutosController(IUnitOfWork uof) {
            _uof = uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get() => Ok(_uof.ProdutoRepository.GetAll());

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> GetById(int id) {

            return Ok(_uof.ProdutoRepository.GetById( p => p.Id == id ));

        }

        [HttpGet("ByCategoria/{id:int}", Name = "ProdutosPorCategoria")]
        public ActionResult<IEnumerable<Produto>> ByCategoria(int id) {
            return Ok(_uof.ProdutoRepository.GetProdutosCategoria(id));
        }

        [HttpPost]
        public ActionResult<Produto> Post(Produto produto) {

            var newProduto = _uof.ProdutoRepository.Create(produto);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterProduto", new { id = newProduto.Id} , newProduto);

        }

        [HttpPut]
        public ActionResult<Produto> Put(Produto produto) {

            var produtoAlterado = _uof.ProdutoRepository.Update(produto);
            _uof.Commit();

            return Ok(produtoAlterado);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Produto> Delete(int id) {

            var produto = _uof.ProdutoRepository.GetById( p => p.Id == id );
            var deletedProduto = _uof.ProdutoRepository.Delete(produto);

            return Ok(deletedProduto);
        }
    }
}
