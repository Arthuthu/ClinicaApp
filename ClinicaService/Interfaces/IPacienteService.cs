using ClinicaRepository.Models;

namespace ClinicaService.Interfaces
{
    public interface IPacienteService
    {
        Task<IList<string>> Addpaciente(PacienteModel paciente);
        Task Deletepaciente(Guid id);
        Task<IEnumerable<PacienteModel>> GetAllpacientes();
        Task<PacienteModel?> GetpacienteById(Guid id);
        Task Updatepaciente(PacienteModel paciente);
    }
}