using AccountService.Options;
using Microsoft.Extensions.Options;

namespace AccountService.OptionsSetup;

public sealed class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(JwtOptions.SectionName).Bind(options);
    }
}