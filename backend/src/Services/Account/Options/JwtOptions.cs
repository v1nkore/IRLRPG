namespace AccountService.Options;

public record JwtOptions(
	string Issuer,
	string Audience,
	string SecretKey,
	int AccessTokenExpirationSeconds,
	int RefreshTokenExpirationSeconds)
{
	public const string SectionName = "JwtOptions";
}