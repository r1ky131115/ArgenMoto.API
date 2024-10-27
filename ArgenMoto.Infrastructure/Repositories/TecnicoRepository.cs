using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArgenMoto.Infrastructure.Repositories
{
    public class TecnicoRepository : ITecnicoRepository
    {
        private readonly ArgenMotoContext _context;

        public TecnicoRepository(ArgenMotoContext context)
        {
            _context = context;
        }

        public async Task<Tecnico> CreateAsync(Tecnico tecnico)
        {
            await _context.Tecnicos.AddAsync(tecnico);
            await _context.SaveChangesAsync();
            return tecnico;
        }

        public async Task DeleteAsync(int id)
        {
            var tecnico = await _context.Tecnicos.FindAsync(id);
            if (tecnico != null)
            {
                _context.Tecnicos.Remove(tecnico);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Tecnico>> GetAllAsync()
        {
            return await _context.Tecnicos.ToListAsync();
        }

        public async Task<Tecnico> GetByIdAsync(int id)
        {
            return await _context.Tecnicos.FindAsync(id);
        }

        public async Task UpdateAsync(Tecnico tecnico)
        {
            _context.Tecnicos.Update(tecnico);
            await _context.SaveChangesAsync();
        }
    }

}
