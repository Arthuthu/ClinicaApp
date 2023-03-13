using Blazored.LocalStorage;
using ClinicaSite.Models;
using ClinicaSite.Services.LoginService.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ClinicaSite.Services.LoginService.Classes;

public class LoginService : ILoginService
{
	private readonly HttpClient _client;
	private readonly AuthenticationStateProvider _authStateProvider;
	private readonly ILocalStorageService _localStorage;
	private readonly IConfiguration _config;
	private readonly ILogger<LoginService> _logger;
	private string authTokenStorageKey;

	public LoginService(HttpClient client,
		AuthenticationStateProvider authStateProvider,
		ILocalStorageService localStorage,
		IConfiguration config,
		ILogger<LoginService> logger)
	{
		_client = client;
		_authStateProvider = authStateProvider;
		_localStorage = localStorage;
		_config = config;
		_logger = logger;
		authTokenStorageKey = _config["authTokenStorageKey"];
	}

	public async Task<AuthenticatedUserModel> Login(AuthenticationUserModel userForAuthentication)
	{
		var data = new FormUrlEncodedContent(new[]
		{
			new KeyValuePair<string, string>("user", userForAuthentication.Username),
			new KeyValuePair<string, string>("password", userForAuthentication.Password)
		});

		string loginEndpoint = _config["apiLocation"] + _config["loginEndpoint"];
		var authResult = await _client.PostAsync(loginEndpoint, data);
		var authContent = await authResult.Content.ReadAsStringAsync();

		if (authResult.IsSuccessStatusCode is false)
		{
			_logger.LogInformation($"Ocorreu um erro durante o login {authContent}");
			return null;
		}

		var result = JsonSerializer.Deserialize<AuthenticatedUserModel>(
			authContent,
			new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

		await _localStorage.SetItemAsync(authTokenStorageKey, result.Access_Token);

		((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Access_Token);

		_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",
			result.Access_Token);

		return result;
	}

	public async Task Logout()
	{
		await _localStorage.RemoveItemAsync(authTokenStorageKey);
		((AuthStateProvider)_authStateProvider).NotifyUserLogout();
		_client.DefaultRequestHeaders.Authorization = null;
	}
}
