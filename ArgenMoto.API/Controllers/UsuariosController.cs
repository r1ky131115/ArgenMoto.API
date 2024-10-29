using ArgenMoto.Core.DTOs.Usuario;
using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadDTO>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ReadDTO>>(usuarios));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadDTO>> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReadDTO>(usuario));
        }

        [HttpPost]
        public async Task<ActionResult<ReadDTO>> CreateUsuario(CreateDTO usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var createdUsuario = await _usuarioRepository.CreateAsync(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = createdUsuario.Id }, _mapper.Map<ReadDTO>(createdUsuario));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, UpdateDTO usuarioDto)
        {
            if (id != usuarioDto.Id)
            {
                return BadRequest();
            }

            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepository.UpdateAsync(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
