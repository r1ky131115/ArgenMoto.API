using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArgenMoto.Core.Utils
{
    public interface IJwtService
    {
        string GenerateToken(string username);
    }

    public class JwtService : IJwtService
    {
        private readonly string _secretKey;

        public JwtService(string secretKey)
        {
            _secretKey = secretKey;
        }

        public string GenerateToken(string username)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
