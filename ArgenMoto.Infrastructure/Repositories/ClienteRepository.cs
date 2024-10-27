using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArgenMoto.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ArgenMotoContext _context;

        public ClienteRepository(ArgenMotoContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Cliente con ID {id} no encontrado.");
            }
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            var existingCliente = await _context.Clientes.FindAsync(cliente.Id);
            if (existingCliente != null)
            {
                _context.Entry(existingCliente).CurrentValues.SetValues(cliente);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Cliente con ID {cliente.Id} no encontrado.");
            }
        }
    }
}
