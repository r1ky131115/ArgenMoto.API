using ArgenMoto.Core.DTOs.OrdenCompra;
using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesCompraController : ControllerBase
    {
        private readonly IOrdenCompraRepository _ordenCompraRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<OrdenesCompraController> _logger;

        public OrdenesCompraController(
            IOrdenCompraRepository ordenCompraRepository,
            IMapper mapper,
            ILogger<OrdenesCompraController> logger)
        {
            _ordenCompraRepository = ordenCompraRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenCompraResponseDto>>> GetAll()
        {
            try
            {
                var ordenes = await _ordenCompraRepository.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<OrdenCompraResponseDto>>(ordenes));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las órdenes de compra");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenCompraResponseDto>> GetById(int id)
        {
            try
            {
                var orden = await _ordenCompraRepository.GetByIdAsync(id);
                if (orden == null)
                    return NotFound($"Orden de compra con ID {id} no encontrada");

                return Ok(_mapper.Map<OrdenCompraResponseDto>(orden));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la orden de compra {OrdenId}", id);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrdenCompraResponseDto>> Create(OrdenCompraCreateDto ordenCompraDto)
        {
            try
            {
                var ordenCompra = _mapper.Map<OrdenesCompra>(ordenCompraDto);

                // Generar número de orden (puedes personalizar este formato)
                ordenCompra.Numero = $"OC-{DateTime.Now:yyyyMMdd}-{await _ordenCompraRepository.GetNextNumeroOrden()}";

                // Asignar fecha actual
                ordenCompra.Fecha = DateOnly.FromDateTime(DateTime.Now);

                // Establecer estado inicial
                ordenCompra.Estado = "Pendiente";

                // Crear la orden
                var createdOrden = await _ordenCompraRepository.CreateAsync(ordenCompra);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = createdOrden.Id },
                    _mapper.Map<OrdenCompraResponseDto>(createdOrden));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la orden de compra");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(OrdenCompraUpdateEstatus ordenCompra)
        {
            try
            {
                var existingOrden = await _ordenCompraRepository.GetByIdAsync(ordenCompra.Id);
                if (existingOrden == null)
                    return NotFound($"Orden de compra con ID {ordenCompra.Id} no encontrada");

                existingOrden.Estado = ordenCompra.Estado;

                await _ordenCompraRepository.UpdateAsync(existingOrden);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la orden de compra {OrdenId}", ordenCompra.Id);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var orden = await _ordenCompraRepository.GetByIdAsync(id);
                if (orden == null)
                    return NotFound($"Orden de compra con ID {id} no encontrada");

                await _ordenCompraRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la orden de compra {OrdenId}", id);
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
