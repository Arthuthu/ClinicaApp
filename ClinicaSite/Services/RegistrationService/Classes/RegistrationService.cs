﻿using ClinicaSite.Models;
using ClinicaSite.Services.RegistrationService.Interfaces;

namespace ClinicaSite.Services.RegistrationService.Classes;

public class RegistrationService : IRegistrationService
{
	private readonly HttpClient _client;
	private readonly IConfiguration _config;
	private readonly ILogger<RegistrationService> _logger;

	public RegistrationService(HttpClient client,
		IConfiguration config,
		ILogger<RegistrationService> logger)
	{
		_client = client;
		_config = config;
		_logger = logger;
	}

	public async Task<string> RegisterUser(RegistrationModel registrationUser)
	{
		var data = new FormUrlEncodedContent(new[]
		{
			new KeyValuePair<string, string>("username", registrationUser.Username),
			new KeyValuePair<string, string>("password", registrationUser.Password)
		});

		string registerEndpoint = _config["apiLocation"] + _config["registerEndpoint"];
		var authResult = await _client.PostAsync(registerEndpoint, data);
		var authContent = await authResult.Content.ReadAsStringAsync();

		if (authResult.IsSuccessStatusCode is false)
		{
			_logger.LogInformation($"Ocorreu um eror durante o registro de conta da clinica {authContent}");
			return authContent;
		}

		return await authResult.Content.ReadAsStringAsync();
	}
}
