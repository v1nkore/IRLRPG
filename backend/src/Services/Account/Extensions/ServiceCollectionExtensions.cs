using System.Reflection;
using AccountService.Infrastructure;
using AccountService.Infrastructure.Entities;
using AccountService.OptionsSetup;
using AccountService.Services.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace AccountService.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureOptionsSetups(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .ConfigureOptions<JwtOptionsSetup>()
            .ConfigureOptions<JwtBearerOptionsSetup>()
            .ConfigureOptions<ClientOptionsSetup>();
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IJwtProvider, JwtProvider>();
    }

    public static IServiceCollection ConfigureDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        return serviceCollection.AddDbContext<AccountContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Database:Development"));
        });
    }

    public static IServiceCollection ConfigureIdentity(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 7;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;

                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AccountContext>();

        return serviceCollection;
    }

    public static IServiceCollection ConfigureAuthentication(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
	    serviceCollection
		    .AddAuthentication()
		    .AddJwtBearer()
		    .AddGoogle(googleOptions =>
		    {
			    var clientId = configuration["AUTHENTICATION:GOOGLE:CLIENT:ID"];
			    ArgumentException.ThrowIfNullOrEmpty(clientId);
				var clientSecret = configuration["AUTHENTICATION:GOOGLE:CLIENT:SECRET"];
			    ArgumentException.ThrowIfNullOrEmpty(clientSecret);
			    googleOptions.ClientId = clientId;
			    googleOptions.ClientSecret = clientSecret;
			    googleOptions.SignInScheme = IdentityConstants.ExternalScheme;
		    });

        return serviceCollection;
    }

    public static IServiceCollection ConfigureSwagger(this IServiceCollection serviceCollection)
    {
	    serviceCollection.AddSwaggerGen(options =>
	    {
		    var securityScheme = new OpenApiSecurityScheme()
		    {
			    Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
			    Name = "Authorization",
			    In = ParameterLocation.Header,
			    Type = SecuritySchemeType.Http,
			    BearerFormat = "JWT",
			    Scheme = "Bearer"
		    };
		    options.AddSecurityDefinition("Bearer", securityScheme);

		    options.AddSecurityRequirement(
			    new OpenApiSecurityRequirement
			    {
				    {
					    new OpenApiSecurityScheme
					    {
						    Reference = new OpenApiReference
						    {
							    Type = ReferenceType.SecurityScheme, Id = "Bearer"
						    }
					    },
					    new string[] { }
				    }
			    });

		    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
		    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
		});

		return serviceCollection;
	}
}