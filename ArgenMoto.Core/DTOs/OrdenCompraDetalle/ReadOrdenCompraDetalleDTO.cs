using ArgenMoto.Core.DTOs.Articulo;

namespace ArgenMoto.Core.DTOs.OrdenCompraDetalle
{
    public class ReadOrdenCompraDetalleDTO
    {
        public ICollection<ReadArticuloDTO> Articulos { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
