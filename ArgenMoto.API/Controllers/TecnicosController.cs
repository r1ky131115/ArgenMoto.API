using ArgenMoto.Core.DTOs.Tecnico;
using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArgenMoto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicosController : ControllerBase
    {
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IMapper _mapper;

        public TecnicosController(IMapper mapper, ITecnicoRepository tecnicoRepository)
        {
            _tecnicoRepository = tecnicoRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadTecnicoDTO>>> GetTecnicos()
        {
            var tecnicos = await _tecnicoRepository.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ReadTecnicoDTO>>(tecnicos));
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadTecnicoDTO>> GetTecnico(int id)
        {
            var tecnico = await _tecnicoRepository.GetByIdAsync(id);

            if (tecnico == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ReadTecnicoDTO>>(tecnico));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTecnico(int id, ReadTecnicoDTO tecnicoRq)
        {
            if (id != tecnicoRq.Id)
            {
                return BadRequest("El ID del tecnico en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            // Mapear el DTO a la entidad TurnosPreventa
            var tecnico = _mapper.Map<Tecnico>(tecnicoRq);

            try
            {
                // Actualizar el tecnico en el repositorio
                await _tecnicoRepository.UpdateAsync(tecnico);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        
        [HttpPost]
        public async Task<ActionResult<Tecnico>> PostTecnico(ReadTecnicoDTO tecnicoRq)
        {
            // Validación de los datos recibidos
            if (tecnicoRq == null)
            {
                return BadRequest("Los datos del tecnico son inválidos.");
            }

            // Mapear el DTO a la entidad TurnosPreventa
            var tecnico = _mapper.Map<Tecnico>(tecnicoRq);

            try
            {
                // Crear el turno en el repositorio
                await _tecnicoRepository.CreateAsync(tecnico);
                return CreatedAtAction(nameof(GetTecnico), new { id = tecnicoRq.Id }, tecnico);
            }
            catch (Exception ex)
            {
                // Manejar posibles excepciones
                return StatusCode(500, $"Error al crear el tecnico: {ex.Message}");
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTecnico(int id)
        {
            var cliente = await _tecnicoRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            await _tecnicoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
