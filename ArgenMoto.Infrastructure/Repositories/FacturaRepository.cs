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

        public async Task<IEnumerable<Factura>> GetAllAsync()
        {
            return await _context.Facturas.ToListAsync();
        }

        public async Task<Factura> GetByIdAsync(int id)
        {
            return await _context.Facturas.FindAsync(id);
        }
    }

}
