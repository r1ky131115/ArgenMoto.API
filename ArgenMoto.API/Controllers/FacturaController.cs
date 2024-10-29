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

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<FacturaReadDTO>>> GetFacturas()
        //{
        //    var facturas = await _facturaRepository.GetAllAsync();
        //    return Ok(_mapper.Map<IEnumerable<FacturaReadDTO>>(facturas));
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<FacturaReadDTO>> GetFactura(int id)
        //{
        //    var factura = await _facturaRepository.GetByIdAsync(id);
        //    if (factura == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(_mapper.Map<FacturaReadDTO>(factura));
        //}

        //[HttpPost]
        //public async Task<ActionResult<FacturaCreateDTO>> CreateFactura(FacturaCreateDTO facturaDto)
        //{
        //    var factura = _mapper.Map<Factura>(facturaDto);
        //    var createdFactura = await _facturaRepository.CreateAsync(factura);
        //    return CreatedAtAction(nameof(GetFactura), new { id = createdFactura.Id }, _mapper.Map<FacturaCreateDTO>(createdFactura));
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateFactura(int id, FacturaUpdateDTO facturaDto)
        //{
        //    if (id != facturaDto.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var factura = _mapper.Map<Factura>(facturaDto);
        //    // Asumiendo que hay un método para actualizar en el repositorio
        //    await _facturaRepository.UpdateAsync(factura);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFactura(int id)
        //{
        //    var factura = await _facturaRepository.GetByIdAsync(id);
        //    if (factura == null)
        //    {
        //        return NotFound();
        //    }

        //    // Asumiendo que hay un método para eliminar en el repositorio
        //    await _facturaRepository.DeleteAsync(id);
        //    return NoContent();
        //}
    }
}
