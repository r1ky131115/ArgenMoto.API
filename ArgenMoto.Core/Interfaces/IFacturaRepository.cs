﻿using ArgenMoto.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArgenMoto.Core.Interfaces
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Factura>> GetAllByUserIdAsync(int id);
        Task<Factura> GetByIdAsync(int id);
        Task<Factura> CreateAsync(Factura factura);
        Task UpdateAsync(Factura factura);
        Task DeleteAsync(int id);
    }

}
