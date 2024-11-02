namespace ArgenMoto.Core.DTOs.OrdenCompraDetalle
{
    public class OrdenCompraDetalleResponseDto
    {
        public int IdArticulo { get; set; }
        public string CodigoArticulo { get; set; }
        public string DescripcionArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
    }
}
