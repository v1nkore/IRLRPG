using System.Security.Claims;
using AccountService.Constants;
using AccountService.Extensions;
using AccountService.Infrastructure.Entities;
using AccountService.Models;
using AccountService.Responses;
using AccountService.Services.Jwt;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

builder.Services.AddCors();

builder.Services
	.ConfigureAuthentication(builder.Configuration)
	.ConfigureOptionsSetups()
	.ConfigureServices()
	.ConfigureDatabase(builder.Configuration)
	.ConfigureIdentity();

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
		options.RoutePrefix = string.Empty;
	});
}

var origin = builder.Configuration.GetValue<string>("ClientOptions:Origin");
ArgumentException.ThrowIfNullOrEmpty(origin);
app.UseCors(options => options.WithOrigins(origin));

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("api/account/register", (CancellationToken cancellationToken) => Results.Ok());

app.MapPost("api/account/login", async (
	LoginModel loginModel, 
	UserManager<ApplicationUser> userManager,
	IJwtProvider jwtProvider,
	CancellationToken cancellationToken) =>
{
	var user = await userManager.FindByEmailAsync(loginModel.Email);
	if (user is null)
	{
		return Results.BadRequest();
	}

	if (!await userManager.CheckPasswordAsync(user, loginModel.Password))
	{
		return Results.BadRequest();
	}

	var accessToken = jwtProvider.GenerateAccessToken(user.Id);
	var refreshToken = jwtProvider.GenerateRefreshToken();
	var jwtOptions = jwtProvider.GetOptions();
	user.RefreshToken = refreshToken;
	user.RefreshTokenExpiration = DateTime.UtcNow.AddSeconds(jwtOptions.RefreshTokenExpirationSeconds);

	return Results.Ok(new LoginResponse(user.Id, accessToken, refreshToken, user.RefreshTokenExpiration.Value));
});

app.Run();