using ArgenMoto.Core.DTOs.Tecnico;
using ArgenMoto.Core.Entities;

namespace ArgenMoto.Core.Interfaces
{
    public interface ITecnicoRepository
    {
        Task<IEnumerable<Tecnico>> GetAllAsync();
        Task<Tecnico> GetByIdAsync(int id);
        Task<Tecnico> CreateAsync(Tecnico tecnico);
        Task UpdateAsync(Tecnico tecnico);
        Task DeleteAsync(int id);
    }
}
