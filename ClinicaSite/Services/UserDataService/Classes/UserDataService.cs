using Blazored.LocalStorage;
using ClinicaSite.Models;
using ClinicaSite.Services.UserDataService.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ClinicaSite.Services.UserDataService.Classes;
public class UserDataService : IUserDataService
{
	private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;
    private readonly IConfiguration _config;
	private readonly HttpClient _client;
	private readonly ILogger<UserDataService> _logger;

    public UserDataService(AuthenticationStateProvider authenticationStateProvider,
		IConfiguration config,
		ILocalStorageService localStorage,
		HttpClient client,
		ILogger<UserDataService> logger)
	{
		_authenticationStateProvider = authenticationStateProvider;
        _config = config;
        _localStorage = localStorage;
		_client = client;
        _logger = logger;
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

	public async Task<ClinicaModel> GetClinicaModel(Guid id)
	{
        string getClinicaByIdEndpoint = _config["apiLocation"] + _config["getClinicaByIdEndpoint"] + $"/{id}";
        var authResult = await _client.GetAsync(getClinicaByIdEndpoint);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger.LogInformation($"Ocorreu um erro durante o carregamento da clinica: {authContent}");
            return null;
        }

        var clinicaModel = JsonConvert.DeserializeObject<ClinicaModel>(authContent);

        return clinicaModel;
    }

    public async Task<string> UpdateClinica(ClinicaModel clinica)
    {
        var data = new FormUrlEncodedContent(new[]
        {
                new KeyValuePair<string, string>("id", clinica.Id.ToString()),
                new KeyValuePair<string, string>("name", clinica.Name)
            });

        string updateClinicaEndpoint = _config["apiLocation"] + _config["updateClinicaEndpoint"];
        var authResult = await _client.PutAsync(updateClinicaEndpoint, data);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger.LogInformation($"Ocorreu um erro ao atualizar a clinica: {authContent}");
            return null;
        }

        return await authResult.Content.ReadAsStringAsync();
    }
}
