using ArgenMoto.Core.Entities;

namespace ArgenMoto.Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> CreateAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
        Task<bool> ExisteDocumentoAsync(string numeroDocumento);
        Task<IEnumerable<TurnosPreventa>> GetAllTurnosAsync();
        Task<IEnumerable<TurnosPreventa>> GetTurnosByClienteIdAsync(int clienteId);
        Task<Cliente> GetClienteConTurnosAsync(int id);
        Task UpdateTurnoAsync(TurnosPreventa turno);
    }
}
