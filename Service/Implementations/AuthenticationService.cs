using Jīao.Models.Enum;
using Jīao.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jīao.Service.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _config;

        public AuthenticationService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateTokenJWT(userType UserType, int userId, string firstName, string lastName)
        {
            return UserType switch
            {
                userType.User => GenerateToken(userId, firstName, lastName, "User"),
                userType.Seller => GenerateToken(userId, firstName, lastName, "Seller"),
                _ => throw new ArgumentException("Invalid user type")
            };
        }

        private string GenerateToken(int id, string firstName, string lastName, string role)
        {
            var securityPassword = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim("given_name", firstName),
                new Claim("family_name", lastName),
                new Claim(ClaimTypes.Role, role)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _config["Authentication:Issuer"],
                _config["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(7),
                credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}