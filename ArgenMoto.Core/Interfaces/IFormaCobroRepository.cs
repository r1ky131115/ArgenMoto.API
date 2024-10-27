using ArgenMoto.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArgenMoto.Core.Interfaces
{
    public interface IFormaCobroRepository
    {
        Task<IEnumerable<FormasCobro>> GetAllAsync();
        Task<FormasCobro> GetByIdAsync(int id);
        Task<FormasCobro> CreateAsync(FormasCobro formaCobro);
    }

}
