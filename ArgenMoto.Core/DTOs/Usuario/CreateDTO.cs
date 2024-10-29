namespace ArgenMoto.Core.DTOs.Usuario
{
    public class CreateDTO
    {
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateOnly FechaCreacion { get; set; }
        public string Estado { get; set; } = null!;
    }
}
