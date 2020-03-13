using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;

namespace Payment.Domain.Jwttoken
{
    public class Jwttoken
    {

        public SecurityKey Chave { get; }
        public SigningCredentials SigningCredentials { get; }

        public static string Secret = "jiCxQjP7LZ0rPKL_6wcmxjzTDNc3qBuFHep3QUjmRFAd_Fwd1sPCIcI5peyaEd6R8CSaKoeioWg";

        public static string GenerateToken(Usuario usuario)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes(Jwttoken.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                   (new Claim[]
                      {
                          new Claim(ClaimTypes.Name, usuario.Username.ToString()),
                          new Claim(ClaimTypes.Role, usuario.role.ToString())
                      }
                    ),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials =
                    new SigningCredentials
                        (
                        new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature
                        )
                    
            
            };
            var token = TokenHandler.CreateToken( tokenDescriptor );
            
            return TokenHandler.WriteToken(token);
        }
    }
}