using Microsoft.IdentityModel.Tokens;
using SecondApi.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SecondApi.Services.Implementations {
    public class TokenService : ITokenService {
        public JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration _config) {

            var key = _config.GetSection("JWT").GetValue<string>("SecurityKey");

            var encodeKey = System.Text.Encoding.UTF8.GetBytes(key!);

            var securityKey = new SigningCredentials(new SymmetricSecurityKey(encodeKey), SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor { 
                Audience = _config.GetSection("JWT").GetValue<string>("ValidAudience"),
                Expires = DateTime.UtcNow.AddMinutes(_config.GetSection("JWT").GetValue<int>("RefreshTokenExpiryInMinutes")),
                Issuer = _config.GetSection("JWT").GetValue<string>("ValidIssuer"),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = securityKey

            };

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
        }

        public string GenerateRefreshToken() {

            var randomSecureNumber = new byte[128];

            var randomGeneratorNumber = RandomNumberGenerator.Create();
            randomGeneratorNumber.GetBytes(randomSecureNumber);

            var refreshToken = Convert.ToBase64String(randomSecureNumber);

            return refreshToken;
        }

        public ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token, IConfiguration _config) {

            var key = _config.GetSection("JWT").GetValue<string>("SecurityKey");

            var securityKey = System.Text.Encoding.UTF8.GetBytes(key);

            var tokenValidationParameters = new TokenValidationParameters() {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey( securityKey )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if ( securityToken is not JwtSecurityToken ||  )
        }
    }
}
