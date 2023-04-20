using Blazored.LocalStorage;
using ClinicaSite.Models;
using ClinicaSite.Services.ConsultaService.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;

namespace ConsultaSite.Services.ConsultaService.Classes;

public class ConsultaService : IConsultaService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;
    private readonly NavigationManager _navigationManager;
    private readonly IConfiguration _config;
    private readonly HttpClient _client;
    private readonly ILogger<ConsultaService> _logger;

    public ConsultaService(AuthenticationStateProvider authenticationStateProvider,
        IConfiguration config,
        ILocalStorageService localStorage,
        NavigationManager navigationManager,
        HttpClient client,
        ILogger<ConsultaService> logger)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _config = config;
        _localStorage = localStorage;
        _navigationManager = navigationManager;
        _client = client;
        _logger = logger;
    }

    public async Task<IList<ConsultaModel>?> GetAllConsultas(Guid clinicaId)
    {
        string getAllConsultasEndpoint = _config["apiLocation"] + _config["getAllConsultasEndpoint"] + $"/{clinicaId}";
        var authResult = await _client.GetAsync(getAllConsultasEndpoint);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger.LogInformation($"Ocorreu um erro durante o carregamento dos pacientes: {authContent}");
            return null;
        }

        var consultaModel = JsonConvert.DeserializeObject<IList<ConsultaModel>>(authContent);

        return consultaModel;
    }

    public async Task<ConsultaModel> GetConsultaById(Guid id)
    {
        string getConsultaByIdEndpoint = _config["apiLocation"] + _config["getConsultaByIdEndpoint"] + $"/{id}";
        var authResult = await _client.GetAsync(getConsultaByIdEndpoint);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger.LogInformation($"Ocorreu um erro durante o carregamento da consulta: {authContent}");
            return null;
        }

        var clinicaModel = JsonConvert.DeserializeObject<ConsultaModel>(authContent);

        return clinicaModel;
    }

    public async Task<string> UpdateConsulta(ConsultaModel clinica)
    {
        var data = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("id", clinica.Id.ToString()),
            new KeyValuePair<string, string>("data", clinica.Data.ToString()),
            new KeyValuePair<string, string>("descricao", clinica.Descricao),
        });

        string updateConsultaEndpoint = _config["apiLocation"] + _config["updateConsultaEndpoint"];
        var authResult = await _client.PutAsync(updateConsultaEndpoint, data);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger.LogInformation($"Ocorreu um erro ao atualizar a consulta: {authContent}");
            return null;
        }

        return await authResult.Content.ReadAsStringAsync();
    }

    public async Task<string> CreateConsulta(ConsultaModel consulta)
    {
        var data = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("data", consulta.Data.ToString()),
            new KeyValuePair<string, string>("descricao", consulta.Descricao),
            new KeyValuePair<string, string>("pacienteid", consulta.PacienteId.ToString()),
            new KeyValuePair<string, string>("clinicaid", consulta.ClinicaId.ToString())

        });

        string createConsultaEndpoint = _config["apiLocation"] + _config["createConsultaEndpoint"];
        var authResult = await _client.PostAsync(createConsultaEndpoint, data);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger.LogInformation($"Ocorreu um erro durante a criação da consulta: {authContent}");
            return null;
        }

        return await authResult.Content.ReadAsStringAsync();
    }

    public async Task<string> DeleteConsulta(Guid id)
    {
        string deleteConsultaEndpoint = _config["apiLocation"] + _config["deleteConsultaEndpoint"] + $"/{id}";
        var authResult = await _client.DeleteAsync(deleteConsultaEndpoint);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger.LogInformation($"Ocorreu um erro para deletar a consulta: {authContent}");
            return null;
        }

        return authContent;
    }
}
