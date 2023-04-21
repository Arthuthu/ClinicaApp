using ClinicaSite.Models;

namespace ClinicaSite.Services.ConsultaService.Interfaces
{
    public interface IConsultaService
    {
        Task<string> CreateConsulta(ConsultaModel consulta);
        Task<string> DeleteConsulta(Guid id);
        Task<IList<ConsultaModel>?> GetAllConsultas(Guid clinicaId);
        Task<ConsultaModel> GetConsultaById(Guid id);
        Task<List<ConsultaModel>> GetConsultasByPacienteId(Guid clinicaId, Guid pacienteId);
        Task<string> UpdateConsulta(ConsultaModel clinica);
    }
}