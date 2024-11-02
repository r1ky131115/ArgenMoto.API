using ArgenMoto.Core.Entities;
using ArgenMoto.Core.Interfaces;
using ArgenMoto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ArgenMoto.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ArgenMotoContext _dbContext;

        public UsuarioRepository(ArgenMotoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _dbContext.Usuarios
                .Where(u => u.Id == id)
                .Include(c => c.Cliente)
                .FirstAsync();
        }

        public async Task<Usuario?> GetByUsernameAsync(string username)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _dbContext.Usuarios.Update(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await GetByIdAsync(id);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteEmailAsync(string email)
        {
            return await _dbContext.Usuarios.AnyAsync(u => u.Email == email);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task<Usuario?> ObtenerPorEmailAsync(string email)
        {
            return await _dbContext.Usuarios?
                .Where(u => u.Email == email)
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync();
        }
    }
}
