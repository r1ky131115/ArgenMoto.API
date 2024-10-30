namespace ArgenMoto.Core.DTOs.Articulo
{
    public class UpdateArticuloDTO
    {
        public int IdArticulo { get; set; }
        public string CodigoArticulo { get; set; }
        public string? Descripcion { get; set; }
        public int? StockActual { get; set; }
        public decimal? Precio { get; set; }
    }
}
