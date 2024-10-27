using System;
using System.Collections.Generic;

namespace ArgenMoto.Core.Entities
{
    public class OrdenesCompra
    {
        public int Id { get; set; }
        public string Numero { get; set; } = null!;
        public DateOnly Fecha { get; set; }
        public int IdCliente { get; set; }
        public string RazonSocial { get; set; } = null!;
        public string? Domicilio { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public decimal? PrecioMario { get; set; }
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal PrecioReal { get; set; }
        public string? Iva { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
        public virtual Cliente Cliente { get; set; } = null!;
        public virtual ICollection<OrdenCompraDetalle> OrdenCompraDetalles { get; set; } = new List<OrdenCompraDetalle>();
    }
}
