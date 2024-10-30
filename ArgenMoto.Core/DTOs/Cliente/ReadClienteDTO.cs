using ArgenMoto.Core.Entities;

namespace ArgenMoto.Core.DTOs.Cliente
{
    public class ReadClienteDTO
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string? RazonSocial { get; set; }
        public string? Apellido { get; set; }
        public string Nombre { get; set; }
        public string? Domicilio { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public string? Telefono { get; set; }
        public string Email { get; set; }

        public virtual ICollection<OrdenesCompra> OrdenesCompras { get; set; } = new List<OrdenesCompra>();
        public virtual ICollection<TurnosPreventa> TurnosPreventa { get; set; } = new List<TurnosPreventa>();
    }
}
