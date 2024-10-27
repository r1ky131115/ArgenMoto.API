namespace ArgenMoto.Core.Entities
{
    public class Repuesto
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
        public int? IdArticulo { get; set; }
        public int? IdProveedor { get; set; }

        public virtual Articulo? Articulo { get; set; }
        public virtual Proveedor? Proveedor { get; set; }
    }
}
