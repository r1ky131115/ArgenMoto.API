namespace ArgenMoto.Core.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public string TipoDocumento { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public string? RazonSocial { get; set; }
        public string? Apellido { get; set; }
        public string Nombre { get; set; } = null!;
        public DateOnly FechaRegistro { get; set; }
        public string? Domicilio { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public string? Telefono { get; set; }
        public string Email { get; set; } = null!;


        public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();
        public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
        public virtual ICollection<HistorialPedido> HistorialPedidos { get; set; } = new List<HistorialPedido>();
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<TurnosPreventa> TurnosPreventa { get; set; } = new List<TurnosPreventa>();
    }
}
