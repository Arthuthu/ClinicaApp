using ClinicaRepository.Models;

namespace ClinicaService.Interfaces
{
    public interface IConsultaService
    {
        Task<ConsultaModel> CreateConsulta(ConsultaModel consulta);
        Task DeleteConsulta(Guid id);
        Task<IEnumerable<ConsultaModel>> GetAllConsultas();
        Task<ConsultaModel?> GetConsultaById(Guid id);
        Task UpdateConsulta(ConsultaModel paciente);
    }
}