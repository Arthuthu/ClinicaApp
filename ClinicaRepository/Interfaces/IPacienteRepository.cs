using ClinicaRepository.Models;

namespace ClinicaRepository.Interfaces
{
    public interface IPacienteRepository
    {
        Task AddPaciente(PacienteModel paciente);
        Task DeletePaciente(Guid id);
        Task<IEnumerable<PacienteModel>> GetAllPacientes(Guid clinicaId);
        Task<PacienteModel?> GetPacientesByName(PacienteModel paciente);
        Task<PacienteModel?> GetPacientesId(Guid id);
        Task<PacienteModel?> GetPacienteByCPF(Guid clinicaId, string CPF);

		Task UpdatePaciente(PacienteModel paciente);
    }
}