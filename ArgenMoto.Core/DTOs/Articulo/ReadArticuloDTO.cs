using System;

namespace ArgenMoto.Core.DTOs.Articulo
{
    public class ReadArticuloDTO
    {
        public int Id { get; set; }
        public string CodigoArticulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public string Cilindro { get; set; }
    }
}