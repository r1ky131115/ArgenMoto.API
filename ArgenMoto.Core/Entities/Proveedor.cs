using System.Collections.Generic;

namespace ArgenMoto.Core.Entities
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Cuit { get; set; } = null!;
        public string? RazonSocial { get; set; }
        public string Apellido { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Domicilio { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public string? Telefono { get; set; }
        public string Email { get; set; } = null!;
        public string? Categoria { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
        public virtual ICollection<Repuesto> Repuestos { get; set; } = new List<Repuesto>();
        public virtual ICollection<OrdenesCompra> OrdenesCompras { get; set; } = new List<OrdenesCompra>();
    }
}
