namespace ArgenMoto.Core.DTOs.Usuario
{
    public class UpdateUsuarioDTO
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
    }
}
