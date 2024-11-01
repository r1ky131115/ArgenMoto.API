using ArgenMoto.Core.DTOs.Carrito;
using ArgenMoto.Core.DTOs.Cliente;
using ArgenMoto.Core.DTOs.Turno;
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
        private readonly ITurnoRepository _turnoRepository;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository clienteRepository, ITurnoRepository turnoRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _turnoRepository = turnoRepository;
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

        [HttpGet("turnos")]
        public async Task<ActionResult<IEnumerable<ReadTurnoDTO>>> GetTurnos()
        {
            var turnos = await _clienteRepository.GetAllTurnosAsync();
            if (turnos == null || !turnos.Any())
            {
                return NotFound();
            }

            var turnosDTO = _mapper.Map<IEnumerable<ReadTurnoDTO>>(turnos);
            return Ok(turnosDTO);
        }

        [HttpGet("turno/{clienteId}")]
        public async Task<ActionResult<IEnumerable<ReadTurnoDTO>>> GetTurnoByClienteId(int clienteId)
        {
            var turnos = await _clienteRepository.GetTurnosByClienteIdAsync(clienteId);
            if (turnos == null || !turnos.Any())
            {
                return NotFound();
            }

            var turnosDTO = _mapper.Map<IEnumerable<ReadTurnoDTO>>(turnos);
            return Ok(turnosDTO);
        }

        [HttpDelete("remove-turno")]
        public async Task<IActionResult> DeleteTurnoByClienteId([FromBody] DeleteTurnoDTO request)
        {
            var cliente = await _clienteRepository.GetClienteConTurnosAsync(request.Cliente_Id);
            if (cliente == null)
            {
                return NotFound($"Cliente con ID {request.Cliente_Id} no encontrado.");
            }

            var turno = cliente.TurnosPreventa.FirstOrDefault(t => t.Id == request.Turno_Id);
            if (turno == null)
            {
                return NotFound($"Turno con ID {request.Turno_Id} no encontrado para el cliente con ID {request.Cliente_Id}.");
            }

            cliente.TurnosPreventa.Remove(turno);

            await _clienteRepository.UpdateAsync(cliente);

            return NoContent(); // Retorna 204 sin contenido indicando que fue exitoso
        }

        [HttpPut("update-turno/{turnoId}")]
        public async Task<IActionResult> UpdateTurno(int turnoId, [FromBody] UpdateTurnoDTO turnoDto)
        {
            if (turnoId != turnoDto.Id)
            {
                return BadRequest("El ID del turno en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            // Mapear el DTO a la entidad TurnosPreventa
            var turno = _mapper.Map<TurnosPreventa>(turnoDto);

            try
            {
                // Actualizar el turno en el repositorio
                await _clienteRepository.UpdateTurnoAsync(turno);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create-turno")]
        public async Task<IActionResult> CreateTurno([FromBody] CreateTurnoDTO turnoDto)
        {
            // Validación de los datos recibidos
            if (turnoDto == null)
            {
                return BadRequest("Los datos del turno son inválidos.");
            }

            // Mapear el DTO a la entidad TurnosPreventa
            var turno = _mapper.Map<TurnosPreventa>(turnoDto);

            try
            {
                // Crear el turno en el repositorio
                await _turnoRepository.CreateAsync(turno);
                return CreatedAtAction(nameof(GetTurnoByClienteId), new { clienteId = turnoDto.IdCliente }, turno);
            }
            catch (Exception ex)
            {
                // Manejar posibles excepciones
                return StatusCode(500, $"Error al crear el turno: {ex.Message}");
            }
        }

        [HttpGet("carrito/{idCliente}")]
        public async Task<ActionResult<IEnumerable<CarritoDto>>> GetCarritoByClienteId(int idCliente)
        {
            var carrito = await _clienteRepository.GetCarritoByClienteIdAsync(idCliente);

            if (carrito == null)
            {
                return NotFound();
            }

            var carritoDetalle = _mapper.Map<CarritoDto>(carrito);

            return Ok(carritoDetalle);
        }


    }
}
