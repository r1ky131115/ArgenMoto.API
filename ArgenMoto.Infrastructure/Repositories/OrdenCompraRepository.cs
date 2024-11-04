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

        public async Task<IEnumerable<OrdenesCompra>> GetAllAsync()
        {
            return await _context.OrdenesCompras
                .Include(o => o.Proveedor)
                .Include(o => o.OrdenCompraDetalles)
                    .ThenInclude(d => d.Articulo)
                .OrderByDescending(o => o.Fecha)
                .ToListAsync();
        }

        public async Task<OrdenesCompra> GetByIdAsync(int id)
        {
            return await _context.OrdenesCompras
                .Include(o => o.Proveedor)
                .Include(o => o.OrdenCompraDetalles)
                    .ThenInclude(d => d.Articulo)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<OrdenesCompra> CreateAsync(OrdenesCompra ordenCompra)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.OrdenesCompras.AddAsync(ordenCompra);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return ordenCompra;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateAsync(OrdenesCompra ordenCompra)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.OrdenesCompras.Update(ordenCompra);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var ordenCompra = await _context.OrdenesCompras
                .Include(o => o.OrdenCompraDetalles)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (ordenCompra == null) return;

            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Eliminar primero los detalles
                _context.OrdenCompraDetalles.RemoveRange(ordenCompra.OrdenCompraDetalles);

                // Luego eliminar la orden de compra
                _context.OrdenesCompras.Remove(ordenCompra);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<int> GetNextNumeroOrden()
        {
            var ultimaOrden = await _context.OrdenesCompras
                .OrderByDescending(o => o.Id)
                .FirstOrDefaultAsync();

            return (ultimaOrden?.Id ?? 0) + 1;
        }
    }
}
