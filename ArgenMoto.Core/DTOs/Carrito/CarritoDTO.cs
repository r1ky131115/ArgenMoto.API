using ArgenMoto.Core.DTOs.Turno;

namespace ArgenMoto.Core.DTOs.Carrito
{
    public class CarritoDto
    {
        public int Id { get; set; }
        public List<CarritoDetalleDto> Detalles { get; set; }
    }

    public class CarritoDetalleDto
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public ArticuloDto Articulo { get; set; }
    }

    public class ArticuloDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string? Año { get; set; }
        public string? Cilindrada { get; set; }
    }

}
