using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArgenMoto.Infrastructure.Repositories
{
    public class FormaCobroRepository : IFormaCobroRepository
    {
        private readonly ArgenMotoContext _context;

        public FormaCobroRepository(ArgenMotoContext context)
        {
            _context = context;
        }

        public async Task<FormasCobro> CreateAsync(FormasCobro formaCobro)
        {
            await _context.FormasCobros.AddAsync(formaCobro);
            await _context.SaveChangesAsync();
            return formaCobro;
        }

        public async Task<IEnumerable<FormasCobro>> GetAllAsync()
        {
            return await _context.FormasCobros.ToListAsync();
        }

        public async Task<FormasCobro> GetByIdAsync(int id)
        {
            return await _context.FormasCobros.FindAsync(id);
        }
    }

}
