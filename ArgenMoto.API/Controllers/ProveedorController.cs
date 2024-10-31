using ArgenMoto.Core.DTOs.Proveedor;
using ArgenMoto.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArgenMoto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IMapper _mapper;

        public ProveedorController(IProveedorRepository proveedorRepository, IMapper mapper)
        {
            _proveedorRepository = proveedorRepository;
            _mapper = mapper;
        }

        [HttpGet("proveedores")]
        public async Task<ActionResult<IEnumerable<ReadProveedorDTO>>> GetProveedores()
        {
            var proveedores = await _proveedorRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ReadProveedorDTO>>(proveedores));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadProveedorDTO>> GetProveedor(int id)
        {
            var proveedor = await _proveedorRepository.GetByIdAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReadProveedorDTO>(proveedor));
        }
    }
}
