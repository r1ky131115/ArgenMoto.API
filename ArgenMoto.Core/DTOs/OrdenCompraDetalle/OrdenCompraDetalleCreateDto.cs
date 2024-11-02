using ArgenMoto.Core.DTOs.Articulo;

namespace ArgenMoto.Core.DTOs.OrdenCompraDetalle
{
    public class OrdenCompraDetalleCreateDto
    {
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
