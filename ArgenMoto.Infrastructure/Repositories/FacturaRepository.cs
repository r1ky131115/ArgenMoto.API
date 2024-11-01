using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArgenMoto.Infrastructure.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ArgenMotoContext _context;

        public FacturaRepository(ArgenMotoContext context)
        {
            _context = context;
        }

        public async Task<Factura> CreateAsync(Factura factura)
        {
            await _context.Facturas.AddAsync(factura);
            await _context.SaveChangesAsync();
            return factura;
        }

        public async Task DeleteAsync(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Factura with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<Factura>> GetAllByUserIdAsync(int idCliente)
        {
            return await _context.Facturas.Where(f => f.IdCliente == idCliente).ToListAsync();
        }

        public async Task<Factura> GetByIdAsync(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                throw new KeyNotFoundException($"Factura with ID {id} not found.");
            }
            return factura;
        }

        public async Task UpdateAsync(Factura factura)
        {
            var existingFactura = await _context.Facturas.FindAsync(factura.Id);
            if (existingFactura != null)
            {
                _context.Entry(existingFactura).CurrentValues.SetValues(factura);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Factura with ID {factura.Id} not found.");
            }
        }
    }
}
