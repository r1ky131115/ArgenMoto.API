namespace ArgenMoto.Core.Utils
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashed);
    }

    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashed)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashed);
        }
    }
}
