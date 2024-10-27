using ArgenMoto.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArgenMoto.Core.Interfaces
{
    public interface ITecnicoRepository
    {
        Task<IEnumerable<Tecnico>> GetAllAsync();
        Task<Tecnico> GetByIdAsync(int id);
        Task<Tecnico> CreateAsync(Tecnico tecnico);
        Task UpdateAsync(Tecnico tecnico);
        Task DeleteAsync(int id); // Dar de baja técnico
    }
}
