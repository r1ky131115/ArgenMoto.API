using ArgenMoto.Core.DTOs.OrdenCompraDetalle;

namespace ArgenMoto.Core.DTOs.OrdenCompra
{
    public class OrdenCompraResponseDto
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateOnly Fecha { get; set; }
        public string RazonSocial { get; set; }
        public decimal PrecioTotal { get; set; }
        public string Estado { get; set; }
        public List<OrdenCompraDetalleResponseDto> Detalles { get; set; }
    }
}
