using AutoMapper;
using FirstApi.DTOs.Entities;
using FirstApi.Models;
using FirstApi.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase {

        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public ProdutosController(IUnitOfWork uof, IMapper mapper) {
            _uof = uof;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoDTO>> Get() => Ok(_mapper.Map<IEnumerable<ProdutoDTO>>(_uof.ProdutoRepository.GetAll()));

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<ProdutoDTO> GetById(int id) {

            return Ok(_mapper.Map<ProdutoDTO>(_uof.ProdutoRepository.GetById( p => p.Id == id )));

        }

        [HttpGet("ByCategoria/{id:int}", Name = "ProdutosPorCategoria")]
        public ActionResult<IEnumerable<ProdutoDTO>> ByCategoria(int id) {
            return Ok(_mapper.Map<IEnumerable<ProdutoDTO>>(_uof.ProdutoRepository.GetProdutosCategoria(id)));
        }

        [HttpGet("produtospaginados")]
        public ActionResult<IEnumerable<ProdutoDTO>> GetByPage([FromQuery] ProdutosParameters parameters) {
            return Ok(_mapper.Map<IEnumerable<ProdutoDTO>>(_uof.ProdutoRepository.GetProdutos(parameters)));
        
        }

        [HttpPost]
        public ActionResult<ProdutoDTO> Post(ProdutoDTO produtoDto) {

            var produto = _mapper.Map<Produto>(produtoDto);
            var newProduto = _mapper.Map<ProdutoDTO>(_uof.ProdutoRepository.Create(produto));
            _uof.Commit();

            return new CreatedAtRouteResult("ObterProduto", new { id = newProduto.Id} , newProduto);

        }

        [HttpPut]
        public ActionResult<ProdutoDTO> Put(ProdutoDTO produtoDto) {

            var produto = _mapper.Map<Produto>(produtoDto);
            var produtoAlterado =_mapper.Map<ProdutoDTO>(_uof.ProdutoRepository.Update(produto));
            _uof.Commit();

            return Ok(produtoAlterado);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ProdutoDTO> Delete(int id) {

            var produto = _uof.ProdutoRepository.GetById( p => p.Id == id );
            var deletedProduto = _mapper.Map<ProdutoDTO>(_uof.ProdutoRepository.Delete(produto));
            _uof.Commit();

            return Ok(deletedProduto);
        }
    }
}
