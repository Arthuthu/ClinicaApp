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

    public Task<IEnumerable<ConsultaModel>> GetAllConsultas()
    {
        return _consultaRepository.GetAllConsultas();
    }

    public async Task<ConsultaModel?> GetConsultaById(Guid id)
    {
        return await _consultaRepository.GetConsultaById(id);
    }

    public async Task<ConsultaModel> CreateConsulta(ConsultaModel consulta)
    {
        consulta.Id = Guid.NewGuid();
        consulta.CreatedDate = DateTime.UtcNow.AddHours(-3);

        await _consultaRepository.CreateConsulta(consulta);

        return consulta;
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
