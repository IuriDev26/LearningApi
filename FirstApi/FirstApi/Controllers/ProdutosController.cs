using AutoMapper;
using FirstApi.DTOs.Entities;
using FirstApi.Filtros;
using FirstApi.Models;
using FirstApi.Pagination;
using FirstApi.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get() => Ok(_mapper.Map<IEnumerable<ProdutoDTO>>(await _uof.ProdutoRepository.GetAllAsync()));

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public async Task<ActionResult<ProdutoDTO>> GetById(int id) {

            return Ok(_mapper.Map<ProdutoDTO>(await _uof.ProdutoRepository.GetByIdAsync( p => p.Id == id )));

        }

        [HttpGet("ByCategoria/{id:int}", Name = "ProdutosPorCategoria")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> ByCategoria(int id) {
            return Ok(_mapper.Map<IEnumerable<ProdutoDTO>>(await _uof.ProdutoRepository.GetProdutosCategoriaAsync(id)));
        }

        [HttpGet("produtospaginados")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetByPage([FromQuery] PaginationParameters parameters) {
            var produtos = await _uof.ProdutoRepository.GetProdutosAsync(parameters);

            return ObterProdutosPagination(produtos);
        }

        [HttpGet("Preco")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> FilterByPrice([FromQuery] ProdutosFiltroPreco parameters) { 

            var produtos = await _uof.ProdutoRepository.FiltroByPrecoAsync(parameters);
            return ObterProdutosPagination(produtos);

            
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
        public async Task<ActionResult<ProdutoDTO>> Delete(int id) {

            var produto = await _uof.ProdutoRepository.GetByIdAsync( p => p.Id == id );
            var deletedProduto = _mapper.Map<ProdutoDTO>(_uof.ProdutoRepository.Delete(produto));
            _uof.Commit();

            return Ok(deletedProduto);
        }

        private ActionResult<IEnumerable<ProdutoDTO>> ObterProdutosPagination(PagedList<Produto> produtos) {

            var metadata = new {
                produtos.PageSize,
                produtos.TotalCount,
                produtos.CurrentPage,
                produtos.TotalPages,
                produtos.HasNext,
                produtos.HasPrevious
            };

            Response.Headers.Append("X-Filter-Preco", JsonConvert.SerializeObject(metadata));

            var produtosDto = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
            return Ok(produtosDto);

        }
    }
}
