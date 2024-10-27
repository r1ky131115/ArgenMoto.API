using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArgenMoto.Infrastructure.Repositories
{
    public class RepuestoRepository : IRepuestoRepository
    {
        private readonly ArgenMotoContext _context;

        public RepuestoRepository(ArgenMotoContext context)
        {
            _context = context;
        }

        public async Task<Repuesto> CreateAsync(Repuesto repuesto)
        {
            await _context.Repuestos.AddAsync(repuesto);
            await _context.SaveChangesAsync();
            return repuesto;
        }

        public async Task DeleteAsync(int id)
        {
            var repuesto = await _context.Repuestos.FindAsync(id);
            if (repuesto != null)
            {
                _context.Repuestos.Remove(repuesto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Repuesto>> GetAllAsync()
        {
            return await _context.Repuestos.ToListAsync();
        }

        public async Task<Repuesto> GetByIdAsync(int id)
        {
            return await _context.Repuestos.FindAsync(id);
        }

        public async Task UpdateAsync(Repuesto repuesto)
        {
            _context.Repuestos.Update(repuesto);
            await _context.SaveChangesAsync();
        }
    }
}
