using Microsoft.AspNetCore.Identity;

namespace AccountService.Infrastructure.Entities;

public sealed class ApplicationUser : IdentityUser<Guid>
{
	public string RefreshToken { get; set; } = string.Empty;
	public DateTime? RefreshTokenExpiration { get; set; }
}