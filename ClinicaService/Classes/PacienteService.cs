using ClinicaRepository.Interfaces;
using ClinicaRepository.Models;
using ClinicaService.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaService.Classes;

public class PacienteService
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMessageHandler _messageHandler;

    public PacienteService(IPacienteRepository pacienteRepository,
        IMessageHandler messageHandler)
    {
        _pacienteRepository = pacienteRepository;
        _messageHandler = messageHandler;
    }

    public Task<IEnumerable<PacienteModel>> GetAllpacientes()
    {
        return _pacienteRepository.GetAllPacientes();
    }

    public async Task<PacienteModel?> GetpacienteById(Guid id)
    {
        return await _pacienteRepository.GetPacientesId(id);
    }

    public async Task<IList<string>> Addpaciente(PacienteModel paciente)
    {
        IList<string> registrationMessages = new List<string>();

        registrationMessages = await _messageHandler.ValidatePacienteRegistration(paciente);

        if (registrationMessages.Count != 0)
        {
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

    public Task Updatepaciente(PacienteModel paciente)
    {
        paciente.UpdatedDate = DateTime.UtcNow.AddHours(-3);
        return _pacienteRepository.UpdatePaciente(paciente);
    }

    public Task Deletepaciente(Guid id)
    {
        return _pacienteRepository.DeletePaciente(id);
    }
}
