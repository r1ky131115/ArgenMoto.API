namespace ArgenMoto.Core.DTOs.Usuario
{
    public class CreateUsuarioDTO
    {
        public string NumeroDocumento { get; set; } = null!;
        public string? Apellido { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Domicilio { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public string? Telefono { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
