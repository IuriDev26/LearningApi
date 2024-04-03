using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SecondApi.Services.Interfaces {
    public interface ITokenService {


        JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration _config);

        string GenerateRefreshToken();

        ClaimsPrincipal GetClaimsPrincipalFromExpiredToken();


    }
}
