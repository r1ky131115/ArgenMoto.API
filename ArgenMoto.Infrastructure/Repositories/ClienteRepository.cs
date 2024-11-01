using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArgenMoto.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ArgenMotoContext _dbContext;

        public ClienteRepository(ArgenMotoContext context)
        {
            _dbContext = context;
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _dbContext.Clientes.Remove(cliente);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Cliente con ID {id} no encontrado.");
            }
        }

        public async Task<bool> ExisteDocumentoAsync(string numeroDocumento)
        {
            return await _dbContext.Clientes.AnyAsync(c => c.NumeroDocumento == numeroDocumento);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<IEnumerable<TurnosPreventa>> GetAllTurnosAsync()
        {
            return await _dbContext.TurnosPreventa
                .Include(t => t.Cliente)
                .Include(t => t.Articulo)
                .Include(t => t.Tecnico)
                .ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }

        public async Task<Cliente> GetClienteConTurnosAsync(int clienteId)
        {
            return await _dbContext.Clientes
                .Include(c => c.TurnosPreventa)
                .FirstOrDefaultAsync(c => c.Id == clienteId);
        }


        public async Task<IEnumerable<TurnosPreventa>> GetTurnosByClienteIdAsync(int clienteId)
        {
            return await _dbContext.TurnosPreventa
                .Where(t => t.Cliente.Id == clienteId)
                .Include(t => t.Cliente)
                .Include(t => t.Articulo)
                .Include(t => t.Tecnico)
                .ToListAsync();
        }


        public async Task UpdateAsync(Cliente cliente)
        {
            var existingCliente = await _dbContext.Clientes.FindAsync(cliente.Id);
            if (existingCliente != null)
            {
                _dbContext.Entry(existingCliente).CurrentValues.SetValues(cliente);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Cliente con ID {cliente.Id} no encontrado.");
            }
        }

        public async Task UpdateTurnoAsync(TurnosPreventa turno)
        {
            var existingTurno = await _dbContext.TurnosPreventa.FindAsync(turno.Id);
            if (existingTurno != null)
            {
                _dbContext.Entry(existingTurno).CurrentValues.SetValues(turno);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Turno con ID {turno.Id} no encontrado.");
            }
        }
    }
}
