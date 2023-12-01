using System.Security.Claims;
using AccountService.Options;

namespace AccountService.Services.Jwt;

public interface IJwtProvider
{
    string GenerateAccessToken(Guid accountId, List<Claim>? claims = null);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    JwtOptions GetOptions();
}