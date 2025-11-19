using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SPMDemo.Models.Dtos;
using SPMDemo.Models.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SPMDemo.Models.Services.Infrastructure
{
    public class AuthService(IOptionsMonitor<JwtOptions> jwtOptions) : IAuthService
    {
        public string? GenerateToken(LoginCredentials credentials)
        {
            // Lista fittizia di utenti autorizzati
            IEnumerable<LoginCredentials> users =
            [
                new LoginCredentials("federico.valeri@unicam.it", "password123")
            ];

            foreach (var user in users)
            {
                if (user.Email == credentials.Email && user.Password == credentials.Password)
                {
                    var claims = new[] {
                        new Claim("Email", credentials.Email),
                        new Claim("Password", credentials.Password) };

                    var key = jwtOptions.CurrentValue.Secret;
                    var keyBytes = Encoding.UTF8.GetBytes(key);

                    JwtSecurityToken token = new(
                        claims: claims,
                        expires: DateTime.UtcNow.AddHours(1),
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(keyBytes),
                            SecurityAlgorithms.HmacSha256)
                    );

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
            }

            return null;
        }
    }
}
