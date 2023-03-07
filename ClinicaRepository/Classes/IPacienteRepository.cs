using ClinicaRepository.Models;

namespace ClinicaRepository.Classes
{
	public interface IPacienteRepository
	{
		Task AddPaciente(PacienteModel paciente);
		Task DeleteUser(Guid id);
		Task<IEnumerable<PacienteModel>> GetAllPacientes();
		Task<PacienteModel?> GetPacientesByName(PacienteModel paciente);
		Task<PacienteModel?> GetPacientesId(Guid id);
		Task UpdatePaciente(PacienteModel paciente);
	}
}