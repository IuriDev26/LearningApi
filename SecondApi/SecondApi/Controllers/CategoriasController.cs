using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondApi.DTOs.Entities;
using SecondApi.Models;
using SecondApi.UnitOfWork;

namespace SecondApi.Controllers {
    
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
        [Authorize( AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme )]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetAll() {

            var categorias = await _uof.CategoriaRepository.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<CategoriaDTO>>(categorias));

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> GetById(int id) {

            var categoria =  await _uof.CategoriaRepository.GetByIdAsync(categoria => categoria.Id == id);

            return Ok(_mapper.Map<CategoriaDTO>(categoria));

        }

        [HttpPost]
        [Authorize( AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminOnly" )]
        public async Task<ActionResult<CategoriaDTO>> Create(CategoriaDTO categoriaDto) {

            if ( categoriaDto == null ) { 
                
                return BadRequest( new Response { Status = "Error", Message = "Categoria Json is Required" });

            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);
            var categoriaCriada = _uof.CategoriaRepository.Create(categoria);
            await _uof.CommitAsync();

            return StatusCode(StatusCodes.Status201Created, categoriaCriada);

        }

        [HttpPut]
        public async Task<ActionResult<CategoriaDTO>> Update(CategoriaDTO categoriaDTO) {

            if ( categoriaDTO == null ) {

                return BadRequest(new Response { Status = "Error", Message = "Categoria Json is Required" });

            }

            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            var categoriaAlterada = _uof.CategoriaRepository.Update(categoria);
            await _uof.CommitAsync();

            return Ok(categoriaAlterada);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id) {

            var categoria = await _uof.CategoriaRepository.GetByIdAsync(categoria => categoria.Id == id);
            var categoriaDeletada = _uof.CategoriaRepository.Delete(categoria);
            await _uof.CommitAsync();

            return Ok(categoriaDeletada);
        }


    }
}
