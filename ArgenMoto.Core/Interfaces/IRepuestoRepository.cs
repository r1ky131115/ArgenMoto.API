using ArgenMoto.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArgenMoto.Core.Interfaces
{
    public interface IRepuestoRepository
    {
        Task<IEnumerable<Repuesto>> GetAllAsync();
        Task<Repuesto> GetByIdAsync(int id);
        Task<Repuesto> CreateAsync(Repuesto repuesto);
        Task UpdateAsync(Repuesto repuesto);
        Task DeleteAsync(int id); // Eliminar repuesto
    }

}
