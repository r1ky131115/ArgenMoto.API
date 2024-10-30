﻿using ArgenMoto.Core.DTOs.Usuario;
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
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(IUsuarioRepository usuarioRepository, IClienteRepository clienteRepository, 
            IMapper mapper, ILogger<UsuariosController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadUsuarioDTO>> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReadUsuarioDTO>(usuario));
        }

        [HttpPost("create-user")]
        public async Task<ActionResult<ReadUsuarioDTO>> CreateUsuario([FromBody] CreateUsuarioDTO usuarioDto)
        {
            try
            {
                // Validar email único
                var existeEmail = await _usuarioRepository.ExisteEmailAsync(usuarioDto.Email);
                if (existeEmail)
                {
                    return BadRequest(new { mensaje = "El email ya se encuentra registrado" });
                }

                // Validar documento único
                var existeDocumento = await _clienteRepository.ExisteDocumentoAsync(usuarioDto.NumeroDocumento);
                if (existeDocumento)
                {
                    return BadRequest(new { mensaje = "El número de documento ya se encuentra registrado" });
                }

                // Crear usuario
                var usuario = new Usuario
                {
                    Username = usuarioDto.Email, // Usar email como username
                    Email = usuarioDto.Email,
                    PasswordHash = usuarioDto.PasswordHash,
                    Rol = "Cliente", // Rol por defecto
                    FechaCreacion = DateOnly.FromDateTime(DateTime.Now),
                    Estado = "Activo"
                };

                // Crear cliente
                var cliente = new Cliente
                {
                    TipoDocumento = "DNI", // Tipo por defecto
                    NumeroDocumento = usuarioDto.NumeroDocumento,
                    Apellido = usuarioDto.Apellido ?? null,
                    Nombre = usuarioDto.Nombre,
                    FechaRegistro = DateOnly.FromDateTime(DateTime.Now),
                    Domicilio = usuarioDto.Domicilio ?? null,
                    Localidad = usuarioDto.Localidad ?? null,
                    Provincia = usuarioDto.Provincia ?? null,
                    Telefono = usuarioDto.Telefono ?? null,
                    Email = usuarioDto.Email
                };

                // Iniciar transacción
                using var transaction = await _usuarioRepository.BeginTransactionAsync();
                try
                {
                    var createdUsuario = await _usuarioRepository.CreateAsync(usuario);

                    cliente.IdUsuario = createdUsuario.Id;
                    await _clienteRepository.CreateAsync(cliente);

                    await transaction.CommitAsync();

                    var usuarioResponse = _mapper.Map<ReadUsuarioDTO>(createdUsuario);
                    return CreatedAtAction(nameof(GetUsuario), new { id = createdUsuario.Id }, usuarioResponse);
                }
                catch (Exception)
                {
                    // Rollback en caso de error
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario y cliente");
                return StatusCode(500, new { mensaje = "Error interno del servidor" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, UpdateUsuarioDTO usuarioDto)
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
