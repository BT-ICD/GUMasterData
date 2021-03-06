using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GUMasterData.API.AuthData
{
    /// <summary>
    /// To generate token for validated user
    /// </summary>

    public class TokenGenerator
    {
        private readonly TokenSettingsOptions options;
        public TokenGenerator(IOptions<TokenSettingsOptions> options)
        {
            this.options = options.Value;
        }
        public TokenModel GenerateToken(string userName, string userRole)
        {
            var tokenString = "";
            var tokenHandler = new JwtSecurityTokenHandler();
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key));
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[] {
                        new Claim(ClaimTypes.Name, userName),
                        new Claim(ClaimTypes.Role, userRole)
                    }),
                Audience = options.Audience,
                Issuer = options.Issuer,
                Expires = DateTime.Now.AddMinutes(options.DurationMinutes),
                SigningCredentials = new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            tokenString = tokenHandler.WriteToken(token);
            return new TokenModel()
            {
                Token = tokenString,
                Expiration = token.ValidTo.ToLocalTime(),
                Role = userRole
            };
        }
    }
}
