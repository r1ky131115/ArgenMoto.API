using ArgenMoto.Core.DTOs.Carrito;
using ArgenMoto.Core.DTOs.Cliente;
using ArgenMoto.Core.DTOs.Turno;
using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Repositories;
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, UpdateClienteDTO clienteDto)
        {
            if (id != clienteDto.Id)
            {
                return BadRequest();
            }

            var cliente = _mapper.Map<Cliente>(clienteDto);
            await _clienteRepository.UpdateAsync(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
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
                return NoContent();
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
                return NoContent();
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

            _turnoRepository.DeleteAsync(turno.Id);

            return NoContent(); // Retorna 204 sin contenido indicando que fue exitoso
        }

        [HttpDelete("remove-turno-for-admin/{id}")]
        public async Task<ActionResult<IEnumerable<ReadTurnoDTO>>> DeleteTurnoByClienteId(int id)
        {
            var turno = await _turnoRepository.GetByIdAsync(id);
            if (turno == null)
            {
                return NotFound($"Turno con ID {id} no encontrado.");
            }

            // Elimina el turno
            await _turnoRepository.DeleteAsync(turno.Id);
            var turnosActualizados = await _clienteRepository.GetAllTurnosAsync();
            var turnosDTO = _mapper.Map<IEnumerable<ReadTurnoDTO>>(turnosActualizados);

            return Ok(turnosDTO);
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

        [HttpPut("update-turno-estado/{turnoId}")]
        public async Task<IActionResult> UpdateTurnoEstado(int turnoId)
        {
            try
            {
                var turno = await _turnoRepository.GetByIdAsync(turnoId);

                if (turno == null)
                {
                    return NotFound("El turno con el ID especificado no fue encontrado.");
                }

                turno.Estado = turno.Estado == "Pendiente" ? "Finalizado" : "Pendiente";

                await _turnoRepository.UpdateAsync(turno);

                // Obtener la lista de turnos actualizada y retornarla
                var turnos = await _clienteRepository.GetAllTurnosAsync();
                var turnosDTO = _mapper.Map<IEnumerable<ReadTurnoDTO>>(turnos);
                return Ok(turnosDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el turno: {ex.Message}");
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


            turno.NumeroTurno = $"T-{DateTime.Now:yyyyMMdd}-{await _turnoRepository.GetNextNumeroTurno()}";

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
