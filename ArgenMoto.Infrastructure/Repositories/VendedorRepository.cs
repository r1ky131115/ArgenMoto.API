using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArgenMoto.Infrastructure.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ArgenMotoContext _context;

        public VendedorRepository(ArgenMotoContext context)
        {
            _context = context;
        }

        public async Task<Vendedor> CreateAsync(Vendedor vendedor)
        {
            await _context.Vendedores.AddAsync(vendedor);
            await _context.SaveChangesAsync();
            return vendedor;
        }

        public async Task DeleteAsync(int id)
        {
            var vendedor = await _context.Vendedores.FindAsync(id);
            if (vendedor != null)
            {
                _context.Vendedores.Remove(vendedor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Vendedor>> GetAllAsync()
        {
            return await _context.Vendedores.ToListAsync();
        }

        public async Task<Vendedor> GetByIdAsync(int id)
        {
            return await _context.Vendedores.FindAsync(id);
        }

        public async Task UpdateAsync(Vendedor vendedor)
        {
            _context.Vendedores.Update(vendedor);
            await _context.SaveChangesAsync();
        }
    }
}
