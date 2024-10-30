using ArgenMoto.Core.DTOs.Articulo;
using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticuloRepository _articuloRepository;
        private readonly IMapper _mapper;

        public ArticulosController(IArticuloRepository articuloRepository, IMapper mapper)
        {
            _articuloRepository = articuloRepository;
            _mapper = mapper;
        }

        [HttpGet("articulos")]
        public async Task<ActionResult<IEnumerable<ReadArticuloDTO>>> GetArticulos()
        {
            var articulos = await _articuloRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ReadArticuloDTO>>(articulos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadArticuloDTO>> GetArticulo(int id)
        {
            var articulo = await _articuloRepository.GetByIdAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReadArticuloDTO>(articulo));
        }

        [HttpPost]
        public async Task<ActionResult<CreateArticuloDTO>> CreateArticulo(CreateArticuloDTO articuloDto)
        {
            var articulo = _mapper.Map<Articulo>(articuloDto);
            await _articuloRepository.CreateAsync(articulo);
            return CreatedAtAction(nameof(GetArticulo), new { id = articulo.Id }, _mapper.Map<CreateArticuloDTO>(articulo));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticulo(int id, UpdateArticuloDTO articuloDto)
        {
            if (id != articuloDto.IdArticulo)
            {
                return NotFound();
            }

            var articuloToUpdate = _mapper.Map<Articulo>(articuloDto);
            await _articuloRepository.UpdateAsync(articuloToUpdate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var articulo = await _articuloRepository.GetByIdAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            await _articuloRepository.DeleteAsync(articulo.Id);
            return Ok();
        }
    }
}