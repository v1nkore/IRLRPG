namespace AccountService.Responses
{
	public record LoginResponse(
		Guid AccountId,
		string AccessToken,
		string RefreshToken,
		DateTime RefreshTokenExpirationTime);
}
