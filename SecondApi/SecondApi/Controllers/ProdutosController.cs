using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondApi.DTOs.Entities;
using SecondApi.Models;
using SecondApi.UnitOfWork;

namespace SecondApi.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase {

        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public ProdutosController(IUnitOfWork unitOfWork, IMapper mapper) {
            _uof = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAll() {

            var produtos = await _uof.ProdutoRepository.GetAllAsync();


            return Ok(_mapper.Map<IEnumerable<ProdutoDTO>>(produtos));

        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> GetById(int id) {

            var produto = await _uof.ProdutoRepository.GetByIdAsync( produto => produto.Id == id );

            return Ok(_mapper.Map<ProdutoDTO>(produto));

        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Create(ProdutoDTO produtoDto) {

            if ( produtoDto == null) {

                return BadRequest(new Response { Status = "Error", Message = "Produto Json is required" });

            }

            var produto = _mapper.Map<Produto>(produtoDto);
            var produtoCriado = _uof.ProdutoRepository.Create(produto);
            await _uof.CommitAsync();

            return StatusCode(StatusCodes.Status201Created, produtoCriado);

        }

        [HttpPut]
        public async Task<ActionResult<ProdutoDTO>> Update(ProdutoDTO produtoDto) {

            if ( produtoDto == null) {
                return BadRequest(new Response { Status = "Error", Message = "Produto Json is required" });
            }

            var produto = _mapper.Map<Produto>(produtoDto);
            var produtoAlterado = _uof.ProdutoRepository.Update(produto);
            await _uof.CommitAsync();

            return Ok(produtoAlterado);

        }

        [HttpDelete]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id) {


            var produto = await _uof.ProdutoRepository.GetByIdAsync(produto => produto.Id == id);
            var produtoDeletado = _uof.ProdutoRepository.Delete(produto);

            return Ok(produtoDeletado);

        }


    }
}
