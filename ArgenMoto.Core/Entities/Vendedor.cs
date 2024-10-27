namespace ArgenMoto.Core.Entities
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
    }
}
