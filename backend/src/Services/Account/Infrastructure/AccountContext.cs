using AccountService.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure;

public sealed class AccountContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
	public AccountContext(DbContextOptions<AccountContext> options) : base(options)
	{
		
	}
}