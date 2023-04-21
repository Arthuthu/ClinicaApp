using ClinicaRepository.Interfaces;
using ClinicaRepository.Models;
using ClinicaService.Interfaces;
using ClinicaService.Validators.Interfaces;

namespace ClinicaService.Classes;

public class ConsultaService : IConsultaService
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IMessageHandler _messageHandler;

    public ConsultaService(IConsultaRepository consultaRepository,
        IMessageHandler messageHandler)
    {
        _consultaRepository = consultaRepository;
        _messageHandler = messageHandler;
    }

    public Task<IEnumerable<ConsultaModel>> GetAllConsultas(Guid clinicaId)
    {
        return _consultaRepository.GetAllConsultas(clinicaId);
    }

    public async Task<ConsultaModel?> GetConsultaById(Guid id)
    {
        return await _consultaRepository.GetConsultaById(id);
    }

    public Task<IEnumerable<ConsultaModel>> GetConsultasByPacienteId(Guid clinicaId, Guid pacienteId)
    {
		return _consultaRepository.GetConsultasByPacienteId(clinicaId, pacienteId);
	}

	public async Task<IList<string>> CreateConsulta(ConsultaModel consulta)
    {
        IList<string> registrationMessages = new List<string>();

        if (consulta.Data <= DateTime.UtcNow.AddHours(-3))
        {
            registrationMessages.Add("Não é possivel agendar uma consulta em uma data que não seja futura");

            return registrationMessages;
        }

        try
        {
            consulta.Id = Guid.NewGuid();
            consulta.CreatedDate = DateTime.UtcNow.AddHours(-3);

            await _consultaRepository.CreateConsulta(consulta);

            registrationMessages.Add("Consulta agendada com sucesso");
        }
        catch (Exception ex)
        {
            registrationMessages.Add($"Não foi possivel agendar a consulta {ex.Message}");
        }

        return registrationMessages;
    }

    public Task UpdateConsulta(ConsultaModel paciente)
    {
        paciente.UpdatedDate = DateTime.UtcNow.AddHours(-3);
        return _consultaRepository.UpdateConsulta(paciente);
    }

    public Task DeleteConsulta(Guid id)
    {
        return _consultaRepository.DeleteConsulta(id);
    }
}
