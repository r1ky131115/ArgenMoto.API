using ArgenMoto.Core.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace ArgenMoto.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario?> GetByUsernameAsync(string username);
        Task<Usuario> CreateAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
        Task<bool> ExisteEmailAsync(string email);
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<Usuario?> ObtenerPorEmailAsync(string email);
    }
}
