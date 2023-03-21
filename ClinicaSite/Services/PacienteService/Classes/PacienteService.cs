using ClinicaSite.Models;
using ClinicaSite.Services.PacienteService.Interfaces;
using Newtonsoft.Json;

namespace ClinicaSite.Services.PacienteService.Classes;

public class PacienteService : IPacienteService
{
	private readonly HttpClient _client;
	private readonly IConfiguration _config;
	private readonly ILogger<PacienteService> _logger;

	public PacienteService(HttpClient client,
	IConfiguration config,
	ILogger<PacienteService> logger)
	{
		_client = client;
		_config = config;
		_logger = logger;
	}

    public async Task<IList<PacienteModel>?> GetAllPacientes(Guid clinicaId)
    {
        string getAllPacientesEndpoint = _config["apiLocation"] + _config["getAllPacientesEndpoint"] + $"/{clinicaId}";
        var authResult = await _client.GetAsync(getAllPacientesEndpoint);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            _logger.LogInformation($"Ocorreu um erro durante o carregamento dos pacientes: {authContent}");
            return null;
        }

        var pacienteModel = JsonConvert.DeserializeObject<IList<PacienteModel>>(authContent);

        return pacienteModel;
    }

	public async Task<PacienteModel?> GetPacienteById(Guid pacienteId)
	{
		string getPacienteByIdEndpoint = _config["apiLocation"] + _config["getPacienteByIdEndpoint"] + $"/{pacienteId}";
		var authResult = await _client.GetAsync(getPacienteByIdEndpoint);
		var authContent = await authResult.Content.ReadAsStringAsync();

		if (authResult.IsSuccessStatusCode is false)
		{
			_logger.LogInformation($"Ocorreu um erro durante o carregamento do paciente: {authContent}");
			return null;
		}

		var pacienteModel = JsonConvert.DeserializeObject<PacienteModel>(authContent);

		return pacienteModel;
	}

	public async Task<string> RegisterPaciente(PacienteModel paciente)
	{
		var data = new FormUrlEncodedContent(new[]
		{
			new KeyValuePair<string, string>("nome", paciente.Nome),
			new KeyValuePair<string, string>("sobrenome", paciente.Sobrenome),
			new KeyValuePair<string, string>("cpf", paciente.CPF),
			new KeyValuePair<string, string>("cep", paciente.CEP),
			new KeyValuePair<string, string>("estado", paciente.Estado),
			new KeyValuePair<string, string>("cidade", paciente.Cidade),
			new KeyValuePair<string, string>("bairro", paciente.Bairro),
			new KeyValuePair<string, string>("rua", paciente.Rua),
			new KeyValuePair<string, string>("numerorua", paciente.NumeroRua),
			new KeyValuePair<string, string>("cel", paciente.Cel),
			new KeyValuePair<string, string>("email", paciente.Email),
			new KeyValuePair<string, string>("clinicaid", paciente.ClinicaId.ToString()),
		});

		string registerPacienteEndpoint = _config["apiLocation"] + _config["registerPacienteEndpoint"];
		var authResult = await _client.PostAsync(registerPacienteEndpoint, data);
		var authContent = await authResult.Content.ReadAsStringAsync();

		if (authResult.IsSuccessStatusCode is false)
		{
			_logger.LogInformation($"Ocorreu um erro durante a criação do roadmap: {authContent}");
			return null;
		}

		return await authResult.Content.ReadAsStringAsync();
	}
}
