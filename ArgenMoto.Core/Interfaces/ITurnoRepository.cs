using ArgenMoto.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArgenMoto.Core.Interfaces
{
    public interface ITurnoRepository
    {
        Task<IEnumerable<TurnosPreventa>> GetAllAsync();
        Task<TurnosPreventa> GetByIdAsync(int id);
        Task<TurnosPreventa> CreateAsync(TurnosPreventa turno);
        Task UpdateAsync(TurnosPreventa turno);
        Task DeleteAsync(int id);
    }
}
