using ArgenMoto.Core.DTOs.Factura;
using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IMapper _mapper;

        public FacturaController(IFacturaRepository facturaRepository, IMapper mapper)
        {
            _facturaRepository = facturaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadDTO>>> GetFacturas()
        {
            var facturas = await _facturaRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ReadDTO>>(facturas));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadDTO>> GetFactura(int id)
        {
            var factura = await _facturaRepository.GetByIdAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReadDTO>(factura));
        }

        [HttpPost]
        public async Task<ActionResult<CreateDTO>> CreateFactura(CreateDTO facturaDto)
        {
            var factura = _mapper.Map<Factura>(facturaDto);
            var createdFactura = await _facturaRepository.CreateAsync(factura);
            return CreatedAtAction(nameof(GetFactura), new { id = createdFactura.Id }, _mapper.Map<CreateDTO>(createdFactura));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFactura(int id, UpdateDTO facturaDto)
        {
            var existingFactura = await _facturaRepository.GetByIdAsync(id);
            if (existingFactura == null)
            {
                return NotFound();
            }

            _mapper.Map(facturaDto, existingFactura);
            await _facturaRepository.UpdateAsync(existingFactura);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            var factura = await _facturaRepository.GetByIdAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            // Asumiendo que hay un método para eliminar en el repositorio
            await _facturaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
