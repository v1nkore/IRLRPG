using AccountService.Options;
using Microsoft.Extensions.Options;

namespace AccountService.OptionsSetup
{
	public class ClientOptionsSetup : IConfigureOptions<ClientOptions>
	{
		private readonly IConfiguration _configuration;

		public ClientOptionsSetup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void Configure(ClientOptions options)
		{
			_configuration.GetSection(ClientOptions.SectionName).Bind(options);
		}
	}
}
