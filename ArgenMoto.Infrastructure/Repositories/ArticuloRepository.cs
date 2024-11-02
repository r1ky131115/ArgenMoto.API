using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArgenMoto.Infrastructure.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly ArgenMotoContext _context;

        public ArticuloRepository(ArgenMotoContext context)
        {
            _context = context;
        }

        public async Task<Articulo> CreateAsync(Articulo articulo)
        {
            await _context.Articulos.AddAsync(articulo);
            await _context.SaveChangesAsync();
            return articulo;
        }

        public async Task DeleteAsync(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Artículo con ID {id} no encontrado.");
            }
        }

        public async Task<IEnumerable<Articulo>> GetAllAsync()
        {
            return await _context.Articulos.ToListAsync();
        }

        public async Task<Articulo> GetByIdAsync(int id)
        {
            return await _context.Articulos.FindAsync(id);
        }

        public async Task<IEnumerable<Articulo>> GetByProveedorIdAsync(int proveedorId)
        {
            return await _context.Articulos
                .Where(a => a.IdProveedor == proveedorId)
                .ToListAsync();
        }


        public async Task UpdateAsync(Articulo articulo)
        {
            var existingArticulo = await _context.Articulos.FindAsync(articulo.Id);
            if (existingArticulo != null)
            {
                _context.Entry(existingArticulo).CurrentValues.SetValues(articulo);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Artículo con ID {articulo.Id} no encontrado.");
            }
        }
    }
}
