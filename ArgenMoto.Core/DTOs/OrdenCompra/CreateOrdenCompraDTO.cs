using ArgenMoto.Core.DTOs.OrdenCompraDetalle;

namespace ArgenMoto.Core.DTOs.OrdenCompra
{
    public class OrdenCompraCreateDto
    {
        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string? Domicilio { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal PrecioReal { get; set; }
        public string? Estado { get; set; }
        public List<OrdenCompraDetalleCreateDto> OrdenCompraDetalles { get; set; }
    }
}
