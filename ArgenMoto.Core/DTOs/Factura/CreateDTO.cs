namespace ArgenMoto.Core.DTOs.Factura
{
    public class CreateDTO
    {
        public string NumeroPedido { get; set; } = null!;
        public DateOnly Fecha { get; set; }
        public string Apellido { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal MontoTotal { get; set; }
        public string? Iva { get; set; }
        public string? Estado { get; set; }
        public int IdCliente { get; set; }
        public int IdFormaCobro { get; set; }
    }
}
