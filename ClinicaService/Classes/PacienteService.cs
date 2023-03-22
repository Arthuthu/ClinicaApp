using ClinicaRepository.Interfaces;
using ClinicaRepository.Models;
using ClinicaService.Interfaces;
using ClinicaService.Validators.Interfaces;

namespace ClinicaService.Classes;

public class PacienteService : IPacienteService
{
	private readonly IPacienteRepository _pacienteRepository;
	private readonly IMessageHandler _messageHandler;

	public PacienteService(IPacienteRepository pacienteRepository,
		IMessageHandler messageHandler)
	{
		_pacienteRepository = pacienteRepository;
		_messageHandler = messageHandler;
	}

	public Task<IEnumerable<PacienteModel>> GetAllPacientes(Guid clinicaId)
	{
		return _pacienteRepository.GetAllPacientes(clinicaId);
	}

	public async Task<PacienteModel?> GetPacienteById(Guid id)
	{
		return await _pacienteRepository.GetPacientesId(id);
	}

	public async Task<IList<string>> AddPaciente(PacienteModel paciente)
	{
		IList<string> registrationMessages = new List<string>();

		registrationMessages = await _messageHandler.ValidatePacienteRegistration(paciente);

		if (registrationMessages.Count != 0)
		{
			return registrationMessages;
		}

		var isPacienteRegistered = await VerifiyIfCPFIsRegistered(paciente.ClinicaId, paciente.CPF);

		if (isPacienteRegistered is true)
		{
			registrationMessages.Add("O cliente ja tem CPF cadastrado");
			return registrationMessages;
		}

		paciente.Id = Guid.NewGuid();
		paciente.CreatedDate = DateTime.UtcNow.AddHours(-3);

		try
		{
			await _pacienteRepository.AddPaciente(paciente);
			registrationMessages.Add("Paciente criado com sucesso");
		}
		catch (Exception ex)
		{
			registrationMessages.Add($"Ocorreu um erro durante a criação do paciente: {ex.Message}");
		}

		return registrationMessages;
	}

	public Task UpdatePaciente(PacienteModel paciente)
	{
		paciente.UpdatedDate = DateTime.UtcNow.AddHours(-3);
		return _pacienteRepository.UpdatePaciente(paciente);
	}

	public Task Deletepaciente(Guid id)
	{
		return _pacienteRepository.DeletePaciente(id);
	}

	private async Task<bool> VerifiyIfCPFIsRegistered(Guid clinicaId, string CPF)
	{
		var paciente = await _pacienteRepository.GetPacienteByCPF(clinicaId, CPF);

		if (paciente is null)
		{
			return false;
		}

		return true;
	}
}
