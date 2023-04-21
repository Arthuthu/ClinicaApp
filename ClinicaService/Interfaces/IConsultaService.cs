using ClinicaRepository.Models;

namespace ClinicaService.Interfaces
{
    public interface IConsultaService
    {
        Task<IList<string>> CreateConsulta(ConsultaModel consulta);
        Task DeleteConsulta(Guid id);
        Task<IEnumerable<ConsultaModel>> GetAllConsultas(Guid clinicaId);
        Task<ConsultaModel?> GetConsultaById(Guid id);
        Task<IEnumerable<ConsultaModel>> GetConsultasByPacienteId(Guid clinicaId, Guid pacienteId);
        Task UpdateConsulta(ConsultaModel paciente);
    }
}