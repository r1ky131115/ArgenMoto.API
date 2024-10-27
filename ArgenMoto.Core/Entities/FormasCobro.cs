using System.Collections.Generic;

namespace ArgenMoto.Core.Entities
{
    public class FormasCobro
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;
        public string? Detalle { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
