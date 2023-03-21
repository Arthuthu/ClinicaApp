using ClinicaRepository.Models;

namespace ClinicaService.Interfaces
{
    public interface IPacienteService
    {
        Task<IList<string>> AddPaciente(PacienteModel paciente);
        Task Deletepaciente(Guid id);
        Task<IEnumerable<PacienteModel>> GetAllPacientes(Guid clinicaId);
        Task<PacienteModel?> GetPacienteById(Guid id);
        Task Updatepaciente(PacienteModel paciente);
    }
}