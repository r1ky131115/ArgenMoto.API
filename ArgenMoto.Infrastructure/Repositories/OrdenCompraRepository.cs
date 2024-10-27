using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArgenMoto.Infrastructure.Repositories
{
    public class OrdenCompraRepository : IOrdenCompraRepository
    {
        private readonly ArgenMotoContext _context;

        public OrdenCompraRepository(ArgenMotoContext context)
        {
            _context = context;
        }

        public async Task<OrdenesCompra> CreateAsync(OrdenesCompra ordenCompra)
        {
            await _context.OrdenesCompras.AddAsync(ordenCompra);
            await _context.SaveChangesAsync();
            return ordenCompra;
        }

        public async Task DeleteAsync(int id)
        {
            var ordenCompra = await _context.OrdenesCompras.FindAsync(id);
            if (ordenCompra != null)
            {
                _context.OrdenesCompras.Remove(ordenCompra);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrdenesCompra>> GetAllAsync()
        {
            return await _context.OrdenesCompras.ToListAsync();
        }

        public async Task<OrdenesCompra> GetByIdAsync(int id)
        {
            return await _context.OrdenesCompras.FindAsync(id);
        }

        public async Task UpdateAsync(OrdenesCompra ordenCompra)
        {
            _context.OrdenesCompras.Update(ordenCompra);
            await _context.SaveChangesAsync();
        }
    }

}
