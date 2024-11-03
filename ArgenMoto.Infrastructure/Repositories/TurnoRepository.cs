using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArgenMoto.Infrastructure.Repositories
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly ArgenMotoContext _context;

        public TurnoRepository(ArgenMotoContext context)
        {
            _context = context;
        }

        public async Task<TurnosPreventa> CreateAsync(TurnosPreventa turno)
        {
            await _context.TurnosPreventa.AddAsync(turno);
            await _context.SaveChangesAsync();
            return turno;
        }

        public async Task DeleteAsync(int id)
        {
            var turno = await _context.TurnosPreventa.FindAsync(id);
            if (turno != null)
            {
                _context.TurnosPreventa.Remove(turno);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TurnosPreventa>> GetAllAsync()
        {
            return await _context.TurnosPreventa.ToListAsync();
        }

        public async Task<TurnosPreventa> GetByIdAsync(int id)
        {
            return await _context.TurnosPreventa.FindAsync(id);
        }

        public async Task<int> GetNextNumeroTurno()
        {
            var ultimaOrden = await _context.TurnosPreventa
                .OrderByDescending(o => o.Id)
                .FirstOrDefaultAsync();

            return (ultimaOrden?.Id ?? 0) + 1;
        }

        public async Task UpdateAsync(TurnosPreventa turno)
        {
            _context.TurnosPreventa.Update(turno);
            await _context.SaveChangesAsync();
        }
    }
}
