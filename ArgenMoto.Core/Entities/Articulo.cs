using System.Collections.Generic;

namespace ArgenMoto.Core.Entities
{
    public partial class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal? StockMinimo { get; set; }
        public decimal? StockMaximo { get; set; }
        public decimal? StockActual { get; set; }
        public decimal Precio { get; set; }
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public string? Motor { get; set; }
        public string? NroChasis { get; set; }
        public string? Año { get; set; }
        public string? Cilindrada { get; set; }
        public int? IdProveedor { get; set; }
        public virtual Proveedor? Proveedor { get; set; }

        public virtual ICollection<CarritoDetalle> CarritoDetalles { get; set; } = new List<CarritoDetalle>();
        public virtual ICollection<OrdenCompraDetalle> OrdenCompraDetalles { get; set; } = new List<OrdenCompraDetalle>();
        public virtual ICollection<Repuesto> Repuestos { get; set; } = new List<Repuesto>();
        public virtual ICollection<TurnosPreventa> TurnosPreventa { get; set; } = new List<TurnosPreventa>();
    }
}
