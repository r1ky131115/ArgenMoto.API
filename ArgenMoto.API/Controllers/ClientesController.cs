using ArgenMoto.Core.DTOs.Cliente;
using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<IEnumerable<ReadClienteDTO>>> GetClientes()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ReadClienteDTO>>(clientes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadClienteDTO>> GetCliente(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReadClienteDTO>(cliente));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, UpdateClienteDTO clienteDto)
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
