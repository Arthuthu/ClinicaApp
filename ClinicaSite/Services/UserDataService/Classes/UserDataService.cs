using ClinicaSite.Services.UserDataService.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ClinicaSite.Services.UserDataService.Classes;
public class UserDataService : IUserDataService
{
	private readonly AuthenticationStateProvider _authenticationStateProvider;

	public UserDataService(AuthenticationStateProvider authenticationStateProvider)
	{
		_authenticationStateProvider = authenticationStateProvider;
	}
	public async Task<Guid> GetLoggedInUserId()
	{
		var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
		var user = authenticationState.User;
		var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

		if (userId is null)
		{
			return Guid.Empty;
		}

		return new Guid(userId);
	}
}
