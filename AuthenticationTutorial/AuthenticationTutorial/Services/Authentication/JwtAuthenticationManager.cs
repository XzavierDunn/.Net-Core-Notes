using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthenticationTutorial.Models;

namespace AuthenticationTutorial.Services.Authentication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            { "test1", "password1" }, {"test2", "password2" }
        };

        private readonly string key;
        private readonly IRefreshTokenGenerator refreshTokenGenerator;

        public JwtAuthenticationManager(string key, IRefreshTokenGenerator refreshTokenGenerator)
        {
            this.key = key;
            this.refreshTokenGenerator = refreshTokenGenerator;
        }

        public AuthenticationResponse Authenticate(string username, string password)
        {
            if (!users.Any(user => user.Key == username && user.Value == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = 
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), 
                    SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var refreshToken = refreshTokenGenerator.GenerateToken();

            return new AuthenticationResponse { token = tokenHandler.WriteToken(token), refreshToken = refreshToken };
        }
    }
}
