using ArgenMoto.Core.Entities;

namespace ArgenMoto.Core.Interfaces
{
    public interface IOrdenCompraRepository
    {
        Task<IEnumerable<OrdenesCompra>> GetAllAsync();
        Task<OrdenesCompra> GetByIdAsync(int id);
        Task<OrdenesCompra> CreateAsync(OrdenesCompra ordenCompra);
        Task UpdateAsync(OrdenesCompra ordenCompra);
        Task DeleteAsync(int id);
        Task<int> GetNextNumeroOrden();
    }
}
