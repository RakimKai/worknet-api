using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using worknet_api.Models;

namespace worknet_api.Helpers
{
    public class GenerateToken
    {
        private readonly IConfiguration _config;
        public GenerateToken(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateAccessToken(Korisnik uposlenik)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credendtials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,uposlenik.Email),
                new Claim(ClaimTypes.Email,uposlenik.Email),
                new Claim(ClaimTypes.Role,uposlenik.Role),
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.Now.AddHours(24), signingCredentials: credendtials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
