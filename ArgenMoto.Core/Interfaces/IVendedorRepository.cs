using ArgenMoto.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArgenMoto.Core.Interfaces
{
    public interface IVendedorRepository
    {
        Task<IEnumerable<Vendedor>> GetAllAsync();
        Task<Vendedor> GetByIdAsync(int id);
        Task<Vendedor> CreateAsync(Vendedor vendedor);
        Task UpdateAsync(Vendedor vendedor);
        Task DeleteAsync(int id);
    }
}
