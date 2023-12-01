using AccountService.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace AccountService.OptionsSetup;

public sealed class JwtBearerOptionsSetup : IConfigureOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions;

    public JwtBearerOptionsSetup(IOptions<JwtOptions> options)
    {
        _jwtOptions = options.Value;
    }

    public void Configure(JwtBearerOptions options)
    {
        options.TokenValidationParameters = AppOptions.ConfigureTokenValidationParameters(_jwtOptions);
    }
}