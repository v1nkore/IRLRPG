using System.Text;
using AccountService.Options;
using Microsoft.IdentityModel.Tokens;

namespace AccountService.OptionsSetup;

public class AppOptions
{
    public static readonly TokenValidationParameters TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
    };

    public static TokenValidationParameters ConfigureTokenValidationParameters(JwtOptions jwtOptions)
    {
        var tokenValidationParameters = TokenValidationParameters;
        tokenValidationParameters.ValidAudience = jwtOptions.Audience;
        tokenValidationParameters.ValidIssuer = jwtOptions.Issuer;
        tokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));

        return tokenValidationParameters;
    }
}