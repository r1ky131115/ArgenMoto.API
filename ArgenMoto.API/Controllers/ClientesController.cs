using ArgenMoto.Core.DTOs.Cliente;
using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadDTO>>> GetClientes()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ReadDTO>>(clientes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadDTO>> GetCliente(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReadDTO>(cliente));
        }

        [HttpPost]
        public async Task<ActionResult<CreateDTO>> CreateCliente(UpdateDTO clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            var createdCliente = await _clienteRepository.CreateAsync(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = createdCliente.Id }, _mapper.Map<CreateDTO>(createdCliente));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, UpdateDTO clienteDto)
        {
            if (id != clienteDto.IdCliente)
            {
                return BadRequest();
            }

            var cliente = _mapper.Map<Cliente>(clienteDto);
            await _clienteRepository.UpdateAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            await _clienteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
