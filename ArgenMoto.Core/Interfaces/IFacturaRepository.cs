using ArgenMoto.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArgenMoto.Core.Interfaces
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Factura>> GetAllAsync();
        Task<Factura> GetByIdAsync(int id);
        Task<Factura> CreateAsync(Factura factura);
    }

}
