namespace ArgenMoto.Core.DTOs.Articulo
{
    public class ArticuloCreateDTO
    {
        public string CodigoArticulo { get; set; }
        public string Descripcion { get; set; }
        public int? StockActual { get; set; }
        public decimal Precio { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int NroMotor { get; set; }
        public int NroChasis { get; set; }
        public int Año { get; set; }
        public string Cilindro { get; set; }
    }
}
